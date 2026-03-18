using StyleVibe.Domain.Common;

namespace StyleVibe.Domain.Entities;

public class PurchaseOrder : BaseEntity
{
    public string PoCode { get; set; } = null!;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime? ExpectedDate { get; set; }
    public DateTime? ReceivedDate { get; set; }
    public byte Status { get; set; } = 1; // 1=Draft,2=Sent,3=Confirmed,4=Received,5=Cancelled
    public decimal TotalCost { get; set; }
    public string? Note { get; set; }

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;

    public ICollection<PurchaseOrderDetail> Details { get; set; } = new List<PurchaseOrderDetail>();
}

