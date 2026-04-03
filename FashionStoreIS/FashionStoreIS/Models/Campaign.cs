using System.ComponentModel.DataAnnotations;

namespace FashionStoreIS.Models
{
    public class Campaign : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = "";

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Target segment: "All", "Champions", "Loyal", "PotentialLoyalists", "AtRisk", "Lost", "New",
        /// "Bronze", "Silver", "Gold", "VIP"
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string TargetSegment { get; set; } = "All";

        public int? VoucherId { get; set; }
        public virtual Voucher? Voucher { get; set; }

        [Required]
        [MaxLength(200)]
        public string NotificationTitle { get; set; } = "";

        [Required]
        [MaxLength(1000)]
        public string NotificationMessage { get; set; } = "";

        public bool IsSent { get; set; } = false;
        public DateTime? SentAt { get; set; }
        public int RecipientCount { get; set; } = 0;
    }
}
