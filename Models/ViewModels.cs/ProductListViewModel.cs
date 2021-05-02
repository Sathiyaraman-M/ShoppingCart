using System.Collections.Generic;

namespace ShoppingCart.Models.ViewModels
{
    public class ProductListViewModel
    {        
        public IEnumerable<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}