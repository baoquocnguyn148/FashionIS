using FashionStoreIS.Models;
using FashionStoreIS.Services;
using System.ComponentModel.DataAnnotations;

namespace FashionStoreIS.Areas.Admin.ViewModels
{
    public class CampaignViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên chiến dịch không được để trống")]
        [MaxLength(150)]
        [Display(Name = "Tên chiến dịch")]
        public string Name { get; set; } = "";

        [MaxLength(500)]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime StartDate { get; set; } = DateTime.Today;

        [Required]
        [Display(Name = "Ngày kết thúc")]
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(7);

        [Required]
        [Display(Name = "Nhóm khách hàng mục tiêu")]
        public string TargetSegment { get; set; } = "All";

        [Display(Name = "Voucher đính kèm")]
        public int? VoucherId { get; set; }

        [Required(ErrorMessage = "Tiêu đề thông báo không được để trống")]
        [MaxLength(200)]
        [Display(Name = "Tiêu đề thông báo")]
        public string NotificationTitle { get; set; } = "";

        [Required(ErrorMessage = "Nội dung thông báo không được để trống")]
        [MaxLength(1000)]
        [Display(Name = "Nội dung thông báo")]
        public string NotificationMessage { get; set; } = "";

        // Display only
        public bool IsSent           { get; set; }
        public DateTime? SentAt      { get; set; }
        public int RecipientCount    { get; set; }
        public string? VoucherCode   { get; set; }

        // For dropdowns
        public List<Voucher> AvailableVouchers          { get; set; } = new();
        public List<SegmentOption> AvailableSegments    { get; set; } = SegmentOption.All();

        // Preview
        public List<CustomerRfmSummary> PreviewRecipients { get; set; } = new();
    }

    public class SegmentOption
    {
        public string Value { get; set; } = "";
        public string Label { get; set; } = "";

        public static List<SegmentOption> All() => new()
        {
            new() { Value = "All",               Label = "🌐 Tất cả khách hàng" },
            new() { Value = "Champions",          Label = "🏆 Champions (mua nhiều, chi nhiều)" },
            new() { Value = "Loyal",              Label = "💙 Khách trung thành" },
            new() { Value = "PotentialLoyalists", Label = "⭐ Khách tiềm năng" },
            new() { Value = "New",                Label = "🆕 Khách mới (≤30 ngày)" },
            new() { Value = "AtRisk",             Label = "⚠️ Có nguy cơ rời bỏ" },
            new() { Value = "Lost",               Label = "💔 Đã mất liên lạc (>120 ngày)" },
        };
    }
}
