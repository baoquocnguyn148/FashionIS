using Microsoft.AspNetCore.Mvc;
using StyleVibe.Application.Interfaces;

namespace StyleVibe.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(int? categoryId, CancellationToken cancellationToken = default)
    {
        ViewBag.Categories = await _productService.GetCategoriesAsync(cancellationToken);

        var products = categoryId.HasValue
            ? await _productService.GetProductsByCategoryAsync(categoryId.Value, cancellationToken)
            : await _productService.GetActiveProductsAsync(cancellationToken);

        return View(products);
    }

    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
    {
        var product = await _productService.GetProductByIdAsync(id, cancellationToken);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }
}
