using FashionStoreIS.Data;
using FashionStoreIS.Models;
using FashionStoreIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class AdminNotificationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly INotificationService _notif;

        public AdminNotificationController(ApplicationDbContext db, INotificationService notif)
        {
            _db = db;
            _notif = notif;
        }

        // GET: Admin/AdminNotification
        public async Task<IActionResult> Index(string? userId)
        {
            var query = _db.Notifications.Where(n => !n.IsDeleted);
            if (!string.IsNullOrEmpty(userId))
                query = query.Where(n => n.UserId == userId);

            var list = await query.OrderByDescending(n => n.CreatedAt).Take(200).ToListAsync();
            ViewBag.FilterUserId = userId;
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(string userId, string title, string message, string? actionUrl)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(message))
            {
                TempData["Error"] = "Vui lòng điền đầy đủ thông tin.";
                return RedirectToAction(nameof(Index));
            }
            await _notif.SendAsync(userId, title, message, actionUrl);
            TempData["Success"] = "Đã gửi thông báo thành công.";
            return RedirectToAction(nameof(Index));
        }
    }
}
