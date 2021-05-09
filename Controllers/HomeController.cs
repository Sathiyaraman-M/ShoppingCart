using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.ViewModels;

namespace ShoppingCart.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository repository;
        public HomeController(IProductRepository _repository)
        {
            repository = _repository;
            ProductListViewModel.Categories = repository.Products.Select(p => p.Category).Distinct().OrderBy(p => p);
        }
        public ViewResult Index(string category)
        {
            return View(new ProductListViewModel
            {
                Products = repository.Products.Where(p => p.Category == category || category == null)
            });
        }

        public IActionResult RedirectToCart()
        {
            return RedirectToPage("/Cart");
        }
    }
}