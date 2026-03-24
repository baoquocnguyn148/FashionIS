using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class VouchersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VouchersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var vouchers = await _db.Vouchers.OrderByDescending(v => v.CreatedAt).ToListAsync();
            return View(vouchers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Voucher());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Voucher model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    _db.Vouchers.Update(model);
                }
                else
                {
                    model.CreatedAt = DateTime.Now;
                    _db.Vouchers.Add(model);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var voucher = await _db.Vouchers.FindAsync(id);
            if (voucher == null) return NotFound();
            return View("Create", voucher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var voucher = await _db.Vouchers.FindAsync(id);
            if (voucher != null)
            {
                _db.Vouchers.Remove(voucher);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
