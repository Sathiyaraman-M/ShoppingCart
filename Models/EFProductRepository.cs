using System.Linq;

namespace ShoppingCart.Models
{
    public class EFProductRepository : IProductRepository
    {
        private StoreDbContext context;
        public EFProductRepository(StoreDbContext _context)
        {
            context = _context;
        }
        public IQueryable<Product> Products => context.Products;

        public void CreateProduct(Product product)
        {
            context.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Remove(product);
            context.SaveChanges();
        }

        public void SaveProduct()
        {
            context.SaveChanges();
        }
    }
}