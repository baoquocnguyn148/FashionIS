using StyleVibe.Domain.Common;

namespace StyleVibe.Domain.Entities;

public class Voucher : BaseEntity
{
    public string Code { get; set; } = null!;
    public decimal DiscountAmount { get; set; }
    public decimal? MinOrderAmount { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public int MaxUsageCount { get; set; } = 1;
    public int UsedCount { get; set; } = 0;
    public bool IsActive { get; set; } = true;
}
