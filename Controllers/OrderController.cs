using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Checkout()
        {
            return View();
        }
    }
}