using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart.Models;

namespace ShoppingCart.Pages
{
    public class OrderFailedModel : PageModel
    {
        public Cart cart;
        public OrderFailedModel(Cart _cart)
        {
            cart = _cart;
        }
    }
}