// —м запросы в Data - Storage - EShop

using DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EShopContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IEshopDataContext, EShopContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("GetCategories/{id?}", async (IEshopDataContext context, int? id) => 
    await context.Categories.Where(c => id == null || c.Id == id).ToListAsync());

app.MapGet("GetProducts", async (IEshopDataContext context) => 
     {
         var result = from p in context.Products
                      from c in context.Categories.Include(x => x.IdProucts).Where(pc => pc.IdProucts.Contains(p)).DefaultIfEmpty()
                      select new { p.ProductName, c.CategoryName };

         return await result.ToListAsync();

     });


app.Run();
  