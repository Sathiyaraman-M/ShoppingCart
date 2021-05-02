using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = Lines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public decimal ComputeTotalValues()
        {
            return Lines.Sum(p => p.Quantity * p.Product.Price);
        }
        
        public virtual void RemoveLine(Product product)
        {
            Lines.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public virtual void Clear()
        {
            Lines.Clear();
        }
    }
    public sealed class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}