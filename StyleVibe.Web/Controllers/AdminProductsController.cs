using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;
using StyleVibe.Web.ViewModels.Admin;

namespace StyleVibe.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminProductsController : Controller
{
    private readonly IAppDbContext _context;

    public AdminProductsController(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? categoryId, string? search, int page = 1, CancellationToken cancellationToken = default)
    {
        const int pageSize = 20;
        page = Math.Max(1, page);

        var query = _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Where(p => !p.IsDeleted);

        if (categoryId.HasValue && categoryId.Value > 0)
        {
            query = query.Where(p => p.CategoryId == categoryId.Value);
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            var s = search.Trim();
            query = query.Where(p => p.Name.Contains(s));
        }

        var total = await query.CountAsync(cancellationToken);
        var items = await query
            .OrderByDescending(p => p.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).OrderBy(c => c.Name).ToListAsync(cancellationToken);
        ViewBag.SelectedCategoryId = categoryId;
        ViewBag.Search = search;
        ViewBag.Page = page;
        ViewBag.TotalPages = (int)Math.Ceiling(total / (double)pageSize);

        return View(items);
    }

    [HttpGet]
    public async Task<IActionResult> Create(CancellationToken cancellationToken = default)
    {
        await LoadDropdownsAsync(cancellationToken);
        return View(new ProductViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductViewModel model, CancellationToken cancellationToken = default)
    {
        await LoadDropdownsAsync(cancellationToken);
        if (!ModelState.IsValid) return View(model);

        try
        {
            var now = DateTime.UtcNow;
            var entity = new Product
            {
                Name = model.Name.Trim(),
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                SupplierId = model.SupplierId,
                IsActive = true,
                IsDeleted = false,
                CreatedAt = now
            };

            _context.Products.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Tạo sản phẩm thành công.";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Có lỗi xảy ra: " + ex.Message;
            return View(model);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products
            .Include(p => p.Skus)
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, cancellationToken);

        if (product == null) return NotFound();

        await LoadDropdownsAsync(cancellationToken);
        return View(new ProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            CategoryId = product.CategoryId,
            SupplierId = product.SupplierId,
            IsActive = product.IsActive
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductViewModel model, CancellationToken cancellationToken = default)
    {
        await LoadDropdownsAsync(cancellationToken);
        if (!ModelState.IsValid) return View(model);

        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == model.Id && !p.IsDeleted, cancellationToken);
        if (product == null) return NotFound();

        try
        {
            product.Name = model.Name.Trim();
            product.Description = model.Description;
            product.ImageUrl = model.ImageUrl;
            product.CategoryId = model.CategoryId;
            product.SupplierId = model.SupplierId;
            product.IsActive = model.IsActive;
            product.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Cập nhật sản phẩm thành công.";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Có lỗi xảy ra: " + ex.Message;
            return View(model);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, cancellationToken);
        if (product == null) return NotFound();

        product.IsDeleted = true;
        product.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);
        TempData["SuccessMessage"] = "Xóa sản phẩm thành công.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Supplier)
            .Include(p => p.Skus.Where(s => !s.IsDeleted))
            .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, cancellationToken);

        if (product == null) return NotFound();

        ViewBag.CreateSku = new ProductSkuViewModel { ProductId = product.Id };
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSku(ProductSkuViewModel model, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Dữ liệu SKU không hợp lệ.";
            return RedirectToAction(nameof(Details), new { id = model.ProductId });
        }

        try
        {
            var exists = await _context.ProductSkus.AnyAsync(s => s.SkuCode == model.SkuCode && !s.IsDeleted, cancellationToken);
            if (exists)
            {
                TempData["ErrorMessage"] = "SkuCode đã tồn tại.";
                return RedirectToAction(nameof(Details), new { id = model.ProductId });
            }

            var sku = new ProductSku
            {
                ProductId = model.ProductId,
                SkuCode = model.SkuCode.Trim(),
                Size = model.Size.Trim(),
                Color = model.Color.Trim(),
                CostPrice = model.CostPrice,
                SellingPrice = model.SellingPrice,
                IsActive = model.IsActive,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.ProductSkus.Add(sku);
            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Thêm SKU thành công.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Có lỗi xảy ra: " + ex.Message;
        }

        return RedirectToAction(nameof(Details), new { id = model.ProductId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditSku(int id, ProductSkuViewModel model, CancellationToken cancellationToken = default)
    {
        var sku = await _context.ProductSkus.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted, cancellationToken);
        if (sku == null) return NotFound();

        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Dữ liệu SKU không hợp lệ.";
            return RedirectToAction(nameof(Details), new { id = sku.ProductId });
        }

        try
        {
            var conflict = await _context.ProductSkus.AnyAsync(s => s.Id != id && s.SkuCode == model.SkuCode && !s.IsDeleted, cancellationToken);
            if (conflict)
            {
                TempData["ErrorMessage"] = "SkuCode đã tồn tại.";
                return RedirectToAction(nameof(Details), new { id = sku.ProductId });
            }

            sku.SkuCode = model.SkuCode.Trim();
            sku.Size = model.Size.Trim();
            sku.Color = model.Color.Trim();
            sku.CostPrice = model.CostPrice;
            sku.SellingPrice = model.SellingPrice;
            sku.IsActive = model.IsActive;
            sku.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Cập nhật SKU thành công.";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = "Có lỗi xảy ra: " + ex.Message;
        }

        return RedirectToAction(nameof(Details), new { id = sku.ProductId });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteSku(int id, CancellationToken cancellationToken = default)
    {
        var sku = await _context.ProductSkus.FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted, cancellationToken);
        if (sku == null) return NotFound();

        sku.IsDeleted = true;
        sku.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);
        TempData["SuccessMessage"] = "Xóa SKU thành công.";
        return RedirectToAction(nameof(Details), new { id = sku.ProductId });
    }

    private async Task LoadDropdownsAsync(CancellationToken cancellationToken)
    {
        var categories = await _context.Categories.Where(c => !c.IsDeleted).OrderBy(c => c.Name).ToListAsync(cancellationToken);
        var suppliers = await _context.Suppliers.Where(s => !s.IsDeleted).OrderBy(s => s.Name).ToListAsync(cancellationToken);

        ViewBag.Categories = new SelectList(categories, "Id", "Name");
        ViewBag.Suppliers = new SelectList(suppliers, "Id", "Name");
    }
}

