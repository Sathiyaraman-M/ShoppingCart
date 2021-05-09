using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository OrderRepository;
        private Cart cart;

        public OrderController(IOrderRepository orderRepository, Cart cartService)
        {
            OrderRepository = orderRepository;
            cart = cartService;
        }

        public IActionResult Checkout()
        {
            return View(new Order());
        }
        
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            foreach (CartLine line in cart.Lines)
            {
                if (line.Product.StockQuantity < line.Quantity)
                {
                    return RedirectToPage("/OrderFailed", new { cart = cart });
                }
            }
            if (ModelState.IsValid)
            {
                order.Lines = cart.Lines.ToArray();
                OrderRepository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.OrderID });
            }
            else
            {
                return View();
            }
        }
    }
}