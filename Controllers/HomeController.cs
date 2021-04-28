using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}