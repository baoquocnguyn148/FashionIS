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
        // Lấy sản phẩm mới nhất (sort theo CreatedAt DESC) 
        var allProducts = await _productService.GetActiveProductsAsync(cancellationToken);
        ViewBag.NewArrivals = allProducts.OrderByDescending(p => p.CreatedAt).Take(8);
        return View();
    }
}
