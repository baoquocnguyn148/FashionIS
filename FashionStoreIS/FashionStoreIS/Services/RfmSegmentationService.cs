using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Services
{
    /// <summary>
    /// Phân loại khách hàng theo mô hình RFM (Recency, Frequency, Monetary).
    /// </summary>
    public class RfmSegmentationService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public RfmSegmentationService(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        /// <summary>Tính segment RFM dựa trên số ngày kể từ đơn cuối, số đơn, và tổng chi.</summary>
        public static string GetSegment(int daysSinceLast, int orderCount, decimal totalSpent)
        {
            if (daysSinceLast <= 30 && orderCount >= 5 && totalSpent >= 5_000_000)
                return "Champions";
            if (daysSinceLast <= 60 && orderCount >= 3)
                return "Loyal";
            if (daysSinceLast <= 60 && orderCount >= 1)
                return "PotentialLoyalists";
            if (daysSinceLast <= 30 && orderCount == 1)
                return "New";
            if (daysSinceLast > 30 && daysSinceLast <= 120 && totalSpent >= 1_000_000)
                return "AtRisk";
            if (daysSinceLast > 120)
                return "Lost";
            return "Others";
        }

        public static string GetSegmentLabel(string segment) => segment switch
        {
            "Champions"          => "🏆 Champions",
            "Loyal"              => "💙 Khách trung thành",
            "PotentialLoyalists" => "⭐ Tiềm năng",
            "New"                => "🆕 Mới",
            "AtRisk"             => "⚠️ Có nguy cơ rời bỏ",
            "Lost"               => "💔 Đã mất",
            _                    => "📦 Khác"
        };

        public static string GetSegmentColor(string segment) => segment switch
        {
            "Champions"          => "#f59e0b",
            "Loyal"              => "#6366f1",
            "PotentialLoyalists" => "#10b981",
            "New"                => "#3b82f6",
            "AtRisk"             => "#ef4444",
            "Lost"               => "#64748b",
            _                    => "#94a3b8"
        };

        /// <summary>Lấy toàn bộ users có role "User" kèm thống kê đơn hàng để phân segment.</summary>
        public async Task<List<CustomerRfmSummary>> GetAllCustomerSummariesAsync()
        {
            var users = await _userManager.GetUsersInRoleAsync("User");
            var now = DateTime.Now;
            var result = new List<CustomerRfmSummary>();

            foreach (var user in users)
            {
                var orders = await _db.Orders
                    .Where(o => o.UserId == user.Id && o.Status != OrderStatus.Cancelled)
                    .Select(o => new { o.TotalAmount, o.CreatedAt })
                    .ToListAsync();

                var totalSpent    = orders.Sum(o => o.TotalAmount);
                var orderCount    = orders.Count;
                var lastOrderDate = orders.Max(o => (DateTime?)o.CreatedAt);
                var daysSinceLast = lastOrderDate.HasValue
                    ? (int)(now - lastOrderDate.Value).TotalDays
                    : 9999;

                var tier = user.MembershipPoints switch
                {
                    >= 500 => CustomerTier.Vip,
                    >= 200 => CustomerTier.Gold,
                    >= 50  => CustomerTier.Silver,
                    _      => CustomerTier.Bronze
                };

                result.Add(new CustomerRfmSummary
                {
                    UserId        = user.Id,
                    FullName      = user.FullName ?? user.UserName ?? "Không tên",
                    Email         = user.Email ?? "",
                    Phone         = user.PhoneNumber ?? "",
                    JoinDate      = user.JoinDate,
                    TotalSpent    = totalSpent,
                    OrderCount    = orderCount,
                    LastOrderDate = lastOrderDate,
                    DaysSinceLast = daysSinceLast,
                    Tier          = tier,
                    Points        = user.MembershipPoints,
                    Segment       = GetSegment(daysSinceLast, orderCount, totalSpent)
                });
            }

            return result.OrderByDescending(r => r.TotalSpent).ToList();
        }

        /// <summary>Nhóm khách hàng theo segment.</summary>
        public async Task<Dictionary<string, List<CustomerRfmSummary>>> GetSegmentDictionaryAsync()
        {
            var all = await GetAllCustomerSummariesAsync();
            return all.GroupBy(c => c.Segment)
                      .ToDictionary(g => g.Key, g => g.ToList());
        }

        /// <summary>Lấy danh sách userId của một segment cụ thể.</summary>
        public async Task<List<string>> GetUserIdsBySegmentAsync(string segment)
        {
            if (segment == "All")
            {
                var users = await _userManager.GetUsersInRoleAsync("User");
                return users.Select(u => u.Id).ToList();
            }

            // Tier-based segments
            if (segment is "Bronze" or "Silver" or "Gold" or "VIP")
            {
                var all = await GetAllCustomerSummariesAsync();
                return all.Where(c => c.Tier.ToString() == segment &&
                                      !string.IsNullOrEmpty(c.UserId))
                          .Select(c => c.UserId).ToList();
            }

            // RFM segments
            var summaries = await GetAllCustomerSummariesAsync();
            return summaries.Where(c => c.Segment == segment && !string.IsNullOrEmpty(c.UserId))
                            .Select(c => c.UserId).ToList();
        }
    }

    public class CustomerRfmSummary
    {
        public string UserId        { get; set; } = "";
        public string FullName      { get; set; } = "";
        public string Email         { get; set; } = "";
        public string Phone         { get; set; } = "";
        public DateTime JoinDate    { get; set; }
        public decimal TotalSpent   { get; set; }
        public int OrderCount       { get; set; }
        public DateTime? LastOrderDate { get; set; }
        public int DaysSinceLast    { get; set; }
        public CustomerTier Tier    { get; set; }
        public int Points           { get; set; }
        public string Segment       { get; set; } = "Others";
    }
}
