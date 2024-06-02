using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using MidTerm2IrakliNozadze.Models;

namespace MidTerm2IrakliNozadze.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductsAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string id)
        {
            var cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
            var product = cart.Items.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                var products = await _productService.GetProductsAsync();
                product = products.FirstOrDefault(p => p.Id == id);
                if (product != null)
                {
                    cart.Items.Add(product);
                }
            }

            HttpContext.Session.Set("Cart", cart);
            return Json(new { success = true, cartItemCount = cart.Items.Count });
        }
    }
}