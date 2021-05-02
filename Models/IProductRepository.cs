using System.Linq;

namespace ShoppingCart.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void CreateProduct(Product product);
        void SaveProduct();
        void DeleteProduct(Product product);
    }
}