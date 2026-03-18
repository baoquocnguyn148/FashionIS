using Microsoft.AspNetCore.Mvc;
using StyleVibe.Application.Interfaces;

namespace StyleVibe.Web.Controllers;

public class CartController : Controller
{
    private readonly IProductService _productService;

    public CartController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetCartItems([FromBody] int[] skuIds, CancellationToken cancellationToken = default)
    {
        var items = new List<object>();
        foreach (var skuId in skuIds)
        {
            var sku = await _productService.GetProductSkuByIdAsync(skuId, cancellationToken);
            if (sku != null)
            {
                items.Add(new
                {
                    id = sku.Id,
                    productName = sku.Product?.Name ?? "N/A",
                    size = sku.Size,
                    color = sku.Color,
                    sellingPrice = (double)sku.SellingPrice
                });
            }
        }
        return Json(items);
    }
}
