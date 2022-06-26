
namespace DataAccess.Models
{
    public partial class Product
    {
        public Product()
        {
            IdCategories = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal ProductPrice { get; set; }

        public virtual ICollection<Category> IdCategories { get; set; }
    }
}
