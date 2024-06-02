using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MidTerm2IrakliNozadze.Models;

namespace MidTerm2IrakliNozadze.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(string id)
        {
            var cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            var product = cart.Items.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                cart.Items.Remove(product);
            }

            HttpContext.Session.Set("Cart", cart);
            return Json(new { success = true, cartItemCount = cart.Items.Count });
        }
    }
}