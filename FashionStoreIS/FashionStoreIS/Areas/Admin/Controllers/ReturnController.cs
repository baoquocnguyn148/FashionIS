using FashionStoreIS.Data;
using FashionStoreIS.Models;
using FashionStoreIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class ReturnController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INotificationService _notif;

        public ReturnController(ApplicationDbContext db, UserManager<ApplicationUser> userManager, INotificationService notif)
        {
            _db = db;
            _userManager = userManager;
            _notif = notif;
        }

        // GET: Admin/Return
        public async Task<IActionResult> Index(string? status)
        {
            var query = _db.ReturnRequests
                .Include(r => r.Order)
                .Where(r => !r.IsDeleted);

            if (!string.IsNullOrEmpty(status) && Enum.TryParse<ReturnRequestStatus>(status, true, out var parsedStatus))
                query = query.Where(r => r.Status == parsedStatus);

            var list = await query.OrderByDescending(r => r.CreatedAt).ToListAsync();

            ViewBag.SelectedStatus = status;
            ViewBag.PendingCount = await _db.ReturnRequests.CountAsync(r => !r.IsDeleted && r.Status == ReturnRequestStatus.Pending);
            return View(list);
        }

        // GET: Admin/Return/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var rr = await _db.ReturnRequests
                .Include(r => r.Order)
                    .ThenInclude(o => o.OrderDetails)
                        .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(r => r.Id == id && !r.IsDeleted);

            if (rr == null) return NotFound();

            if (rr.Order?.UserId != null)
                ViewBag.User = await _userManager.FindByIdAsync(rr.Order.UserId);

            return View(rr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id, string? adminNote)
        {
            var rr = await _db.ReturnRequests.Include(r => r.Order).FirstOrDefaultAsync(r => r.Id == id);
            if (rr == null) return NotFound();
            if (rr.Status != ReturnRequestStatus.Pending) return BadRequest();

            rr.Status = ReturnRequestStatus.Approved;
            rr.AdminNote = adminNote;
            rr.ProcessedAt = DateTime.Now;
            rr.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();

            await _notif.SendReturnStatusChangedAsync(rr, adminNote ?? "");
            TempData["Success"] = "Đã duyệt yêu cầu trả hàng.";
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id, string adminNote)
        {
            var rr = await _db.ReturnRequests.Include(r => r.Order).FirstOrDefaultAsync(r => r.Id == id);
            if (rr == null) return NotFound();
            if (rr.Status != ReturnRequestStatus.Pending) return BadRequest();

            rr.Status = ReturnRequestStatus.Rejected;
            rr.AdminNote = adminNote;
            rr.ProcessedAt = DateTime.Now;
            rr.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();

            await _notif.SendReturnStatusChangedAsync(rr, adminNote);
            TempData["Success"] = "Đã từ chối yêu cầu trả hàng.";
            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Complete(int id, decimal refundAmount, string? adminNote)
        {
            var rr = await _db.ReturnRequests.Include(r => r.Order).FirstOrDefaultAsync(r => r.Id == id);
            if (rr == null) return NotFound();
            if (rr.Status != ReturnRequestStatus.Approved) return BadRequest();

            rr.Status = ReturnRequestStatus.Completed;
            rr.RefundAmount = refundAmount;
            rr.AdminNote = adminNote;
            rr.ProcessedAt = DateTime.Now;
            rr.UpdatedAt = DateTime.Now;
            await _db.SaveChangesAsync();

            await _notif.SendReturnStatusChangedAsync(rr, adminNote ?? "");
            TempData["Success"] = $"Đã hoàn tất trả hàng. Hoàn tiền: {refundAmount:N0}₫";
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
