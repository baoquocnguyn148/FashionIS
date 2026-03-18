using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Domain.Entities;

namespace StyleVibe.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminEmployeesController : Controller
{
    private readonly IAppDbContext _context;

    public AdminEmployeesController(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int? storeId, bool? isActive, CancellationToken cancellationToken = default)
    {
        var query = _context.Employees
            .Include(e => e.Store)
            .Where(e => !e.IsDeleted);

        if (storeId.HasValue) query = query.Where(e => e.StoreId == storeId.Value);
        if (isActive.HasValue) query = query.Where(e => e.IsActive == isActive.Value);

        var items = await query.OrderBy(e => e.FullName).ToListAsync(cancellationToken);
        
        ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        ViewBag.StoreId = storeId;
        ViewBag.IsActive = isActive;

        return View(items);
    }

    [HttpGet]
    public async Task<IActionResult> Create(CancellationToken cancellationToken = default)
    {
        ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        return View(new Employee());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Employee employee, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
            return View(employee);
        }

        employee.HireDate = DateTime.UtcNow;
        employee.IsDeleted = false;
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync(cancellationToken);

        TempData["SuccessMessage"] = "Thêm nhân viên thành công.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken = default)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted, cancellationToken);
        if (employee == null) return NotFound();

        ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
        return View(employee);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Employee employee, CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Stores = await _context.Stores.Where(s => !s.IsDeleted && s.IsActive).OrderBy(s => s.Name).ToListAsync(cancellationToken);
            return View(employee);
        }

        var e = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id && !x.IsDeleted, cancellationToken);
        if (e == null) return NotFound();

        e.FullName = employee.FullName;
        e.Phone = employee.Phone;
        e.Email = employee.Email;
        e.Position = employee.Position;
        e.StoreId = employee.StoreId;
        e.IsActive = employee.IsActive;
        e.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        TempData["SuccessMessage"] = "Cập nhật nhân viên thành công.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
    {
        var e = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted, cancellationToken);
        if (e == null) return NotFound();

        e.IsDeleted = true;
        e.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync(cancellationToken);

        TempData["SuccessMessage"] = "Xóa nhân viên thành công.";
        return RedirectToAction(nameof(Index));
    }
}
