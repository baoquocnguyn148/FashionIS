using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models
{
    public class Voucher : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = "";

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal DiscountAmount { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal MinOrderAmount { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        public bool IsActive { get; set; } = true;
        public int MaxUsageCount { get; set; } = 1;
        public int UsedCount { get; set; } = 0;
    }
}
