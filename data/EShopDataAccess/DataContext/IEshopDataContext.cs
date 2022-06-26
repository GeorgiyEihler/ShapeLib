using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataContext
{
    public interface IEshopDataContext
    {

        DbSet<Product> Products { get; set; }    
        DbSet<Category> Categories { get; set; }
        Task<int> SaveChegesAsync(CancellationToken cancellationToken);
    }
}
