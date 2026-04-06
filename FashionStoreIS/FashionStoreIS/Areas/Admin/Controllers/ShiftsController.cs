using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class ShiftsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShiftsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Shifts
        public async Task<IActionResult> Index(int? storeId)
        {
            var query = _context.Shifts.Include(s => s.Store).AsQueryable();
            if (storeId.HasValue)
                query = query.Where(s => s.StoreId == storeId);

            ViewData["Stores"] = new SelectList(_context.Stores, "Id", "Name", storeId);
            return View(await query.ToListAsync());
        }

        // GET: Admin/Shifts/Create
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name");
            return View();
        }

        // POST: Admin/Shifts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,StartTime,EndTime,StoreId,IsActive")] Shift shift)
        {
            if (ModelState.IsValid)
            {
                shift.CreatedAt = DateTime.Now;
                _context.Add(shift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", shift.StoreId);
            return View(shift);
        }

        // GET: Admin/Shifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var shift = await _context.Shifts.FindAsync(id);
            if (shift == null) return NotFound();

            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", shift.StoreId);
            return View(shift);
        }

        // POST: Admin/Shifts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StartTime,EndTime,StoreId,IsActive,CreatedAt")] Shift shift)
        {
            if (id != shift.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    shift.UpdatedAt = DateTime.Now;
                    _context.Update(shift);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Shifts.Any(e => e.Id == shift.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", shift.StoreId);
            return View(shift);
        }

        // POST: Admin/Shifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shift = await _context.Shifts.FindAsync(id);
            if (shift != null)
            {
                _context.Shifts.Remove(shift);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
