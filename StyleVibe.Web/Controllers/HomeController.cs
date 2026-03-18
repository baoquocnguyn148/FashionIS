using Microsoft.AspNetCore.Mvc;
using StyleVibe.Application.Interfaces;

namespace StyleVibe.Web.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;

    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
    {
        ViewBag.Categories = await _productService.GetCategoriesAsync(cancellationToken);
        ViewBag.NewArrivals = await _productService.GetActiveProductsAsync(cancellationToken);
        return View();
    }
}
