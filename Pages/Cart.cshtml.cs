using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingCart.Models;

namespace ShoppingCart.Pages
{
    public class CartModel : PageModel
    {
        private IProductRepository productRepository;
        public CartModel(IProductRepository repository, Cart cartService)
        {
            productRepository = repository;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = productRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(p => p.Product.ProductId == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}