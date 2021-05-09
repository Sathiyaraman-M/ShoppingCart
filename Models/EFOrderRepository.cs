using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext context;
        public EFOrderRepository(StoreDbContext dbContext)
        {
            context = dbContext;
        }

        public IQueryable<Order> Orders => context.Orders.Include(p => p.Lines).ThenInclude(p => p.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(p => p.Product));
            if (order.OrderID == 0)
            {
                foreach (CartLine line in order.Lines)
                {
                    line.Product.StockQuantity -= line.Quantity;
                }
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }        
    }
}