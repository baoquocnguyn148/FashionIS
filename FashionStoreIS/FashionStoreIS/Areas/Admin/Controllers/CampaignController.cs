using FashionStoreIS.Areas.Admin.ViewModels;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using FashionStoreIS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class CampaignController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly RfmSegmentationService _rfm;
        private readonly INotificationService _notif;

        public CampaignController(ApplicationDbContext db,
                                  RfmSegmentationService rfm,
                                  INotificationService notif)
        {
            _db   = db;
            _rfm  = rfm;
            _notif = notif;
        }

        // GET /Admin/Campaign
        public async Task<IActionResult> Index()
        {
            var campaigns = await _db.Campaigns
                .Where(c => !c.IsDeleted)
                .Include(c => c.Voucher)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
            ViewData["Title"] = "Quản lý Campaign";
            return View(campaigns);
        }

        // GET /Admin/Campaign/Create
        public async Task<IActionResult> Create()
        {
            var vm = new CampaignViewModel
            {
                AvailableVouchers = await GetActiveVouchersAsync(),
                StartDate         = DateTime.Today,
                EndDate           = DateTime.Today.AddDays(7)
            };
            ViewData["Title"] = "Tạo Campaign mới";
            return View(vm);
        }

        // POST /Admin/Campaign/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CampaignViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AvailableVouchers = await GetActiveVouchersAsync();
                return View(vm);
            }

            var campaign = new Campaign
            {
                Name                = vm.Name,
                Description         = vm.Description,
                StartDate           = vm.StartDate,
                EndDate             = vm.EndDate,
                TargetSegment       = vm.TargetSegment,
                VoucherId           = vm.VoucherId,
                NotificationTitle   = vm.NotificationTitle,
                NotificationMessage = vm.NotificationMessage,
                IsSent              = false,
                RecipientCount      = 0,
                CreatedAt           = DateTime.Now
            };

            _db.Campaigns.Add(campaign);
            await _db.SaveChangesAsync();

            TempData["Success"] = $"Đã tạo campaign \"{campaign.Name}\" thành công.";
            return RedirectToAction(nameof(Index));
        }

        // GET /Admin/Campaign/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var campaign = await _db.Campaigns.FindAsync(id);
            if (campaign == null) return NotFound();

            var vm = new CampaignViewModel
            {
                Id                  = campaign.Id,
                Name                = campaign.Name,
                Description         = campaign.Description,
                StartDate           = campaign.StartDate,
                EndDate             = campaign.EndDate,
                TargetSegment       = campaign.TargetSegment,
                VoucherId           = campaign.VoucherId,
                NotificationTitle   = campaign.NotificationTitle,
                NotificationMessage = campaign.NotificationMessage,
                IsSent              = campaign.IsSent,
                SentAt              = campaign.SentAt,
                RecipientCount      = campaign.RecipientCount,
                AvailableVouchers   = await GetActiveVouchersAsync()
            };
            ViewData["Title"] = "Chỉnh sửa Campaign";
            return View(vm);
        }

        // POST /Admin/Campaign/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CampaignViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AvailableVouchers = await GetActiveVouchersAsync();
                return View(vm);
            }

            var campaign = await _db.Campaigns.FindAsync(id);
            if (campaign == null) return NotFound();

            if (campaign.IsSent)
            {
                TempData["Error"] = "Không thể chỉnh sửa campaign đã gửi.";
                return RedirectToAction(nameof(Index));
            }

            campaign.Name                = vm.Name;
            campaign.Description         = vm.Description;
            campaign.StartDate           = vm.StartDate;
            campaign.EndDate             = vm.EndDate;
            campaign.TargetSegment       = vm.TargetSegment;
            campaign.VoucherId           = vm.VoucherId;
            campaign.NotificationTitle   = vm.NotificationTitle;
            campaign.NotificationMessage = vm.NotificationMessage;
            campaign.UpdatedAt           = DateTime.Now;

            await _db.SaveChangesAsync();
            TempData["Success"] = "Đã cập nhật campaign.";
            return RedirectToAction(nameof(Index));
        }

        // GET /Admin/Campaign/Preview/5
        public async Task<IActionResult> Preview(int id)
        {
            var campaign = await _db.Campaigns.Include(c => c.Voucher).FirstOrDefaultAsync(c => c.Id == id);
            if (campaign == null) return NotFound();

            var userIds   = await _rfm.GetUserIdsBySegmentAsync(campaign.TargetSegment);
            var summaries = await _rfm.GetAllCustomerSummariesAsync();
            var recipients = summaries.Where(s => userIds.Contains(s.UserId)).ToList();

            var vm = new CampaignViewModel
            {
                Id                  = campaign.Id,
                Name                = campaign.Name,
                Description         = campaign.Description,
                TargetSegment       = campaign.TargetSegment,
                NotificationTitle   = campaign.NotificationTitle,
                NotificationMessage = campaign.NotificationMessage,
                VoucherCode         = campaign.Voucher?.Code,
                IsSent              = campaign.IsSent,
                PreviewRecipients   = recipients
            };

            ViewData["Title"] = $"Preview: {campaign.Name}";
            return View(vm);
        }

        // POST /Admin/Campaign/Send/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Send(int id)
        {
            var campaign = await _db.Campaigns.FindAsync(id);
            if (campaign == null) return NotFound();

            if (campaign.IsSent)
            {
                TempData["Error"] = "Campaign này đã được gửi trước đó.";
                return RedirectToAction(nameof(Index));
            }

            var userIds = await _rfm.GetUserIdsBySegmentAsync(campaign.TargetSegment);
            if (!userIds.Any())
            {
                TempData["Error"] = "Không có khách hàng nào trong nhóm này.";
                return RedirectToAction(nameof(Preview), new { id });
            }

            var actionUrl = campaign.VoucherId.HasValue
                ? "/Cart/Index"
                : "/Account/Index?tab=orders";

            var message = campaign.NotificationMessage;
            if (campaign.VoucherId.HasValue)
            {
                var v = await _db.Vouchers.FindAsync(campaign.VoucherId);
                if (v != null)
                    message += $"\n🎁 Mã giảm giá: {v.Code} (giảm {v.DiscountAmount:N0}₫)";
            }

            var count = await _notif.SendBulkAsync(userIds, campaign.NotificationTitle, message, actionUrl);

            campaign.IsSent          = true;
            campaign.SentAt          = DateTime.Now;
            campaign.RecipientCount  = count;
            await _db.SaveChangesAsync();

            TempData["Success"] = $"Đã gửi campaign tới {count} khách hàng thành công!";
            return RedirectToAction(nameof(Index));
        }

        // POST /Admin/Campaign/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var campaign = await _db.Campaigns.FindAsync(id);
            if (campaign == null) return NotFound();

            campaign.IsDeleted = true;
            await _db.SaveChangesAsync();

            TempData["Success"] = "Đã xóa campaign.";
            return RedirectToAction(nameof(Index));
        }

        // ─── Helper ───────────────────────────────────────────────────────────
        private async Task<List<Voucher>> GetActiveVouchersAsync()
            => await _db.Vouchers
                .Where(v => v.IsActive && v.ExpiryDate >= DateTime.Now)
                .OrderBy(v => v.Code)
                .ToListAsync();
    }
}
