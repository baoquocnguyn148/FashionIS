using StyleVibe.Domain.Common;
using StyleVibe.Domain.Enums;

namespace StyleVibe.Domain.Entities;

public class PurchaseOrder : BaseEntity
{
    public string PoCode { get; set; } = null!;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime? ExpectedDate { get; set; }
    public DateTime? ReceivedDate { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalCost { get; set; }
    public string? Note { get; set; }

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;

    public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();
}

