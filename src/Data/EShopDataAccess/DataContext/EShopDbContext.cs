using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataContext
{
    public partial class EShopContext : DbContext, IEshopDataContext
    {

        public EShopContext(DbContextOptions<EShopContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        public async Task<int> SaveChegesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=GEORGIY-PC;Database=EShop;MultipleActiveResultSets=true;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryName).HasMaxLength(500);

                entity.HasMany(d => d.IdProucts)
                    .WithMany(p => p.IdCategories)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductsCategory",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("IdProuct").HasConstraintName("FK_ProductsCategories_Products"),
                        r => r.HasOne<Category>().WithMany().HasForeignKey("IdCategory").HasConstraintName("FK_ProductsCategories_Categories"),
                        j =>
                        {
                            j.HasKey("IdCategory", "IdProuct");

                            j.ToTable("ProductsCategories");
                        });
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductName).HasMaxLength(500);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(12, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
