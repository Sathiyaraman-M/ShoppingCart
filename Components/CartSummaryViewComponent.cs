using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart Cart;
        public CartSummaryViewComponent(Cart _cart)
        {
            Cart = _cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(Cart);
        }
    }
}