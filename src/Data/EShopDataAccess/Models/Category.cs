
namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            IdProucts = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Product> IdProucts { get; set; }
    }
}
