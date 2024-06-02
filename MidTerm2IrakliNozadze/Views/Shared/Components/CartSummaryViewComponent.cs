using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class CartSummaryViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var cart = HttpContext.Session.Get<Cart>("Cart") ?? new Cart();
        var itemCount = cart.Items.Count;
        return View(itemCount);
    }
}