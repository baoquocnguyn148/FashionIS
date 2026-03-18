using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;

namespace StyleVibe.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminSettingsController : Controller
{
    private readonly IAppDbContext _context;

    public AdminSettingsController(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string tab = "stores", CancellationToken cancellationToken = default)
    {
        ViewBag.ActiveTab = tab;
        ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.Suppliers = await _context.Suppliers.Where(s => !s.IsDeleted).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.Categories = await _context.Categories.Where(c => !c.IsDeleted).OrderBy(c => c.DisplayOrder).ToListAsync(cancellationToken);
        
        return View();
    }

    // --- STORES ---
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateStore(Store store, CancellationToken cancellationToken = default)
    {
        if (ModelState.IsValid)
        {
            store.IsActive = true;
            store.IsDeleted = false;
            _context.Stores.Add(store);
            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Thêm cửa hàng thành công.";
        }
        return RedirectToAction(nameof(Index), new { tab = "stores" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditStore(Store store, CancellationToken cancellationToken = default)
    {
        var s = await _context.Stores.FirstOrDefaultAsync(x => x.Id == store.Id && !x.IsDeleted, cancellationToken);
        if (s != null)
        {
            s.Name = store.Name;
            s.Address = store.Address;
            s.Phone = store.Phone;
            s.ManagerName = store.ManagerName;
            s.IsActive = store.IsActive;
            s.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Cập nhật cửa hàng thành công.";
        }
        return RedirectToAction(nameof(Index), new { tab = "stores" });
    }

    // --- SUPPLIERS ---
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateSupplier(Supplier supplier, CancellationToken cancellationToken = default)
    {
        if (ModelState.IsValid)
        {
            supplier.IsActive = true;
            supplier.IsDeleted = false;
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Thêm nhà cung cấp thành công.";
        }
        return RedirectToAction(nameof(Index), new { tab = "suppliers" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditSupplier(Supplier supplier, CancellationToken cancellationToken = default)
    {
        var s = await _context.Suppliers.FirstOrDefaultAsync(x => x.Id == supplier.Id && !x.IsDeleted, cancellationToken);
        if (s != null)
        {
            s.Name = supplier.Name;
            s.ContactPerson = supplier.ContactPerson;
            s.Phone = supplier.Phone;
            s.Email = supplier.Email;
            s.Address = supplier.Address;
            s.LeadTimeDays = supplier.LeadTimeDays;
            s.IsActive = supplier.IsActive;
            s.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Cập nhật nhà cung cấp thành công.";
        }
        return RedirectToAction(nameof(Index), new { tab = "suppliers" });
    }

    // --- CATEGORIES ---
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCategory(Category category, CancellationToken cancellationToken = default)
    {
        if (ModelState.IsValid)
        {
            category.IsDeleted = false;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Thêm danh mục thành công.";
        }
        return RedirectToAction(nameof(Index), new { tab = "categories" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCategory(Category category, CancellationToken cancellationToken = default)
    {
        var c = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id && !x.IsDeleted, cancellationToken);
        if (c != null)
        {
            c.Name = category.Name;
            c.Description = category.Description;
            c.ImageUrl = category.ImageUrl;
            c.DisplayOrder = category.DisplayOrder;
            c.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Cập nhật danh mục thành công.";
        }
        return RedirectToAction(nameof(Index), new { tab = "categories" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken = default)
    {
        var c = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);
        if (c != null)
        {
            c.IsDeleted = true;
            c.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync(cancellationToken);
            TempData["SuccessMessage"] = "Xóa danh mục thành công.";
        }
        return RedirectToAction(nameof(Index), new { tab = "categories" });
    }
}
