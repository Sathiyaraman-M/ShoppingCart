using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string Category { get; set; }

        public static IEnumerable<string> Categories { get; set; }
    }
}