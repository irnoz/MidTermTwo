using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

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
    public IActionResult AddToCart(string id)
    {
        var cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
        var product = cart.Items.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            var productService = new ProductService(new HttpClient());
            product = productService.GetProductsAsync().Result.FirstOrDefault(p => p.Id == id);
            cart.Items.Add(product);
        }

        HttpContext.Session.Set("Cart", cart);
        return RedirectToAction("Index");
    }
}