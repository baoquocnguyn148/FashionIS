using Microsoft.AspNetCore.Mvc;
using StyleVibe.Application.Interfaces;

namespace StyleVibe.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private const int PageSize = 20;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(
        int? categoryId,
        string? search,
        decimal? minPrice,
        decimal? maxPrice,
        string? sortBy = "newest",
        int page = 1,
        CancellationToken cancellationToken = default)
    {
        ViewBag.Categories = await _productService.GetCategoriesAsync(cancellationToken);
        ViewBag.CurrentCategoryId = categoryId;
        ViewBag.CurrentSearch = search;
        ViewBag.CurrentSortBy = sortBy;
        ViewBag.MinPrice = minPrice;
        ViewBag.MaxPrice = maxPrice;

        var allProducts = await _productService.SearchProductsAsync(
            search, categoryId, minPrice, maxPrice, sortBy, cancellationToken);

        var totalCount = allProducts.Count();
        var products = allProducts
            .Skip((page - 1) * PageSize)
            .Take(PageSize)
            .ToList();

        ViewBag.TotalCount = totalCount;
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)PageSize);

        return View(products);
    }

    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
    {
        var product = await _productService.GetProductByIdAsync(id, cancellationToken);
        if (product == null) return NotFound();
        return View(product);
    }

    // AJAX endpoint: lấy tồn kho của 1 SKU tại store 
    [HttpGet]
    public async Task<IActionResult> GetSkuStock(int skuId, int storeId,
        CancellationToken cancellationToken = default)
    {
        var inventory = await _productService.GetInventoryAsync(skuId, storeId, cancellationToken);
        return Json(new
        {
            quantityOnHand = inventory?.QuantityOnHand ?? 0,
            inStock = (inventory?.QuantityOnHand ?? 0) > 0
        });
    }
}
