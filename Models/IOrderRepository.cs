using System.Linq;

namespace ShoppingCart.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void SaveOrder(Order order);
    }
}