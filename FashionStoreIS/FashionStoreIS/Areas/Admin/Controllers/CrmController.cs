using FashionStoreIS.Areas.Admin.ViewModels;
using FashionStoreIS.Areas.Admin.ViewModels.Crm;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using FashionStoreIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class CrmController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RfmSegmentationService _rfm;
        private readonly INotificationService _notif;

        public CrmController(ApplicationDbContext db,
                             UserManager<ApplicationUser> userManager,
                             RfmSegmentationService rfm,
                             INotificationService notif)
        {
            _db = db;
            _userManager = userManager;
            _rfm = rfm;
            _notif = notif;
        }

        // ─── Customer 360 Profile ─────────────────────────────────────────────

        public async Task<IActionResult> CustomerProfile(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var now = DateTime.Now;

            var orders = await _db.Orders
                .Where(o => o.UserId == id)
                .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .Include(o => o.OrderDetails).ThenInclude(od => od.ProductSku)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            var completedOrders = orders.Where(o => o.Status != OrderStatus.Cancelled).ToList();
            var totalSpent = completedOrders.Sum(o => o.TotalAmount);
            var lastOrderDate = orders.Max(o => (DateTime?)o.CreatedAt);
            var daysSinceLast = lastOrderDate.HasValue ? (int)(now - lastOrderDate.Value).TotalDays : 9999;

            // Loyalty transactions for this user (via customer record)
            var customer = await _db.Customers.FirstOrDefaultAsync(c => c.UserId == id);
            var loyaltyTx = customer != null
                ? await _db.LoyaltyTransactions
                    .Where(lt => lt.CustomerId == customer.Id)
                    .OrderByDescending(lt => lt.CreatedAt)
                    .Take(20)
                    .ToListAsync()
                : new List<LoyaltyTransaction>();

            var returns = await _db.ReturnRequests
                .Include(rr => rr.Order)
                .Where(rr => rr.Order.UserId == id)
                .OrderByDescending(rr => rr.CreatedAt)
                .ToListAsync();

            var notifications = await _db.Notifications
                .Where(n => n.UserId == id)
                .OrderByDescending(n => n.CreatedAt)
                .Take(20)
                .ToListAsync();

            var addresses = await _db.UserAddresses
                .Where(a => a.UserId == id)
                .ToListAsync();

            var tier = user.MembershipPoints switch
            {
                >= 500 => CustomerTier.Vip,
                >= 200 => CustomerTier.Gold,
                >= 50  => CustomerTier.Silver,
                _      => CustomerTier.Bronze
            };

            var segment = RfmSegmentationService.GetSegment(daysSinceLast, completedOrders.Count, totalSpent);

            var vm = new Customer360ViewModel
            {
                User              = user,
                TotalOrders       = orders.Count,
                TotalSpent        = totalSpent,
                AvgOrderValue     = completedOrders.Count > 0 ? totalSpent / completedOrders.Count : 0,
                FirstOrderDate    = orders.Min(o => (DateTime?)o.CreatedAt),
                LastOrderDate     = lastOrderDate,
                DaysSinceLastOrder = daysSinceLast,
                Tier              = tier,
                LoyaltyPoints     = user.MembershipPoints,
                PointHistory      = loyaltyTx,
                RecentOrders      = orders.Take(10).ToList(),
                Returns           = returns,
                Addresses         = addresses,
                NotificationHistory = notifications,
                UnreadNotifications = notifications.Count(n => !n.IsRead),
                RfmSegment        = segment,
                SegmentLabel      = RfmSegmentationService.GetSegmentLabel(segment),
                SegmentColor      = RfmSegmentationService.GetSegmentColor(segment),
                CompletedOrders   = orders.Count(o => o.Status == OrderStatus.Completed),
                CancelledOrders   = orders.Count(o => o.Status == OrderStatus.Cancelled),
                PendingOrders     = orders.Count(o => o.Status == OrderStatus.Pending || o.Status == OrderStatus.Processing),
                ReturnedOrders    = returns.Count,
            };

            ViewData["Title"] = $"Hồ sơ: {user.FullName ?? user.UserName}";
            return View(vm);
        }

        // ─── Customer Timeline ────────────────────────────────────────────────

        public async Task<IActionResult> CustomerTimeline(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var events = new List<TimelineEventViewModel>();

            // Orders
            var orders = await _db.Orders
                .Where(o => o.UserId == id)
                .OrderByDescending(o => o.CreatedAt)
                .Take(30)
                .ToListAsync();

            foreach (var o in orders)
            {
                events.Add(new TimelineEventViewModel
                {
                    EventDate   = o.CreatedAt,
                    EventType   = "Order",
                    Icon        = "fa-bag-shopping",
                    Color       = "#6366f1",
                    Title       = $"Đặt hàng #{o.OrderCode}",
                    Description = $"Tổng: {o.TotalAmount:N0}₫ • Thanh toán: {(o.PaymentMethod == PaymentMethod.EWallet ? "VNPay" : "COD")}",
                    LinkUrl     = $"/Admin/Order/Details/{o.Id}",
                    Badge       = o.Status switch
                    {
                        OrderStatus.Completed  => "Hoàn thành",
                        OrderStatus.Cancelled  => "Đã hủy",
                        OrderStatus.Shipped    => "Đang giao",
                        OrderStatus.Processing => "Đang xử lý",
                        OrderStatus.Pending    => "Chờ xác nhận",
                        _                     => o.Status.ToString()
                    },
                    BadgeColor = o.Status switch
                    {
                        OrderStatus.Completed => "#10b981",
                        OrderStatus.Cancelled => "#ef4444",
                        OrderStatus.Shipped   => "#3b82f6",
                        _                    => "#f59e0b"
                    }
                });
            }

            // Return requests
            var returns = await _db.ReturnRequests
                .Include(rr => rr.Order)
                .Where(rr => rr.Order.UserId == id)
                .OrderByDescending(rr => rr.CreatedAt)
                .ToListAsync();

            foreach (var r in returns)
            {
                events.Add(new TimelineEventViewModel
                {
                    EventDate   = r.CreatedAt,
                    EventType   = "Return",
                    Icon        = "fa-rotate-left",
                    Color       = "#ef4444",
                    Title       = $"Yêu cầu trả hàng – Đơn #{r.OrderId}",
                    Description = $"Lý do: {r.Reason} • Hoàn: {r.RefundAmount:N0}₫",
                    Badge       = r.Status switch
                    {
                        ReturnRequestStatus.Approved  => "Đã duyệt",
                        ReturnRequestStatus.Rejected  => "Từ chối",
                        ReturnRequestStatus.Completed => "Hoàn tất",
                        _                             => "Đang xử lý"
                    },
                    BadgeColor = r.Status == ReturnRequestStatus.Approved || r.Status == ReturnRequestStatus.Completed
                        ? "#10b981" : "#ef4444"
                });
            }

            // Notifications
            var notifs = await _db.Notifications
                .Where(n => n.UserId == id)
                .OrderByDescending(n => n.CreatedAt)
                .Take(15)
                .ToListAsync();

            foreach (var n in notifs)
            {
                events.Add(new TimelineEventViewModel
                {
                    EventDate   = n.CreatedAt,
                    EventType   = "Notification",
                    Icon        = "fa-bell",
                    Color       = "#f59e0b",
                    Title       = n.Title,
                    Description = n.Message,
                    Badge       = n.IsRead ? "Đã đọc" : "Chưa đọc",
                    BadgeColor  = n.IsRead ? "#64748b" : "#6366f1"
                });
            }

            var timeline = events.OrderByDescending(e => e.EventDate).ToList();

            ViewData["Title"] = $"Timeline: {user.FullName ?? user.UserName}";
            ViewBag.User = user;
            return View(timeline);
        }

        // ─── Segments ─────────────────────────────────────────────────────────

        public async Task<IActionResult> Segments(string? filter = null)
        {
            var segmentDict = await _rfm.GetSegmentDictionaryAsync();
            var all         = segmentDict.Values.SelectMany(x => x).ToList();

            var vm = new SegmentsViewModel
            {
                Segments       = segmentDict,
                TotalCustomers = all.Count
            };

            ViewData["Title"] = "Phân khúc khách hàng (RFM)";
            ViewBag.Filter    = filter;
            return View(vm);
        }

        // ─── CRM Analytics ────────────────────────────────────────────────────

        public async Task<IActionResult> Analytics()
        {
            var allSummaries = await _rfm.GetAllCustomerSummariesAsync();
            var now          = DateTime.Now;
            var total        = allSummaries.Count;

            // Tier distribution
            var bronze = allSummaries.Count(c => c.Tier == CustomerTier.Bronze);
            var silver = allSummaries.Count(c => c.Tier == CustomerTier.Silver);
            var gold   = allSummaries.Count(c => c.Tier == CustomerTier.Gold);
            var vip    = allSummaries.Count(c => c.Tier == CustomerTier.Vip);

            // Monthly new customers (last 6 months) – query ApplicationUser JoinDate
            var allUsers = await _userManager.GetUsersInRoleAsync("User");
            var monthlyNew = new List<MonthlyCustomerData>();
            for (int i = 5; i >= 0; i--)
            {
                var target = now.AddMonths(-i);
                var count  = allUsers.Count(u => u.JoinDate.Year == target.Year && u.JoinDate.Month == target.Month);
                monthlyNew.Add(new MonthlyCustomerData { Month = $"{target.Month}/{target.Year}", Count = count });
            }

            // Segment distribution
            var segmentCounts = allSummaries.GroupBy(c => c.Segment)
                .ToDictionary(g => g.Key, g => g.Count());

            // Campaign stats
            var campaigns = await _db.Campaigns.ToListAsync();

            var vm = new CrmAnalyticsViewModel
            {
                TotalCustomers      = total,
                NewCustomers30Days  = allUsers.Count(u => (now - u.JoinDate).TotalDays <= 30),
                NewCustomers90Days  = allUsers.Count(u => (now - u.JoinDate).TotalDays <= 90),
                RepeatCustomers     = allSummaries.Count(c => c.OrderCount > 1),
                AvgClv              = total > 0 ? allSummaries.Sum(c => c.TotalSpent) / total : 0,
                TotalRevenue        = allSummaries.Sum(c => c.TotalSpent),
                AtRiskCount         = segmentCounts.TryGetValue("AtRisk", out var ar) ? ar : 0,
                LostCount           = segmentCounts.TryGetValue("Lost", out var lo) ? lo : 0,
                BronzeCount         = bronze,
                SilverCount         = silver,
                GoldCount           = gold,
                VipCount            = vip,
                SegmentCounts       = segmentCounts,
                MonthlyNewCustomers = monthlyNew,
                TopVipCustomers     = allSummaries.OrderByDescending(c => c.TotalSpent).Take(10).ToList(),
                TotalCampaigns      = campaigns.Count,
                SentCampaigns       = campaigns.Count(c => c.IsSent),
            };

            ViewData["Title"] = "CRM Analytics";
            return View(vm);
        }

        // ─── Send Manual Notification ─────────────────────────────────────────

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendNotification(string userId, string title, string message)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(title))
            {
                TempData["Error"] = "Thông tin thông báo không hợp lệ.";
                return RedirectToAction("CustomerProfile", new { id = userId });
            }

            await _notif.SendAsync(userId, title.Trim(), message.Trim(), "/Account/Index?tab=orders");
            TempData["Success"] = "Đã gửi thông báo thành công.";
            return RedirectToAction("CustomerProfile", new { id = userId });
        }

        // ─── Manual Trigger for Seeding (Maintenance) ───────────────────────
        
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> AppendSampleSeed()
        {
            try
            {
                await DbInitializer.SeedSampleCrmData(_db, _userManager, append: true);
                TempData["Success"] = "Đã nạp THÊM 20 hồ sơ Enterprise & lịch sử mua hàng thành công (không xóa dữ liệu cũ).";
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["Error"] = "Lỗi Database: " + msg;
            }
            return RedirectToAction("Analytics");
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> TriggerSampleSeed()
        {
            try
            {
                await DbInitializer.SeedSampleCrmData(_db, _userManager);
                TempData["Success"] = "Hệ thống đã nạp 20 hồ sơ Enterprise & lịch sử đơn hàng 12 tháng thành công.";
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                TempData["Error"] = "Lỗi Database: " + msg;
            }
            return RedirectToAction("Analytics");
        }
    }
}
