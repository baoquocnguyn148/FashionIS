using StyleVibe.Domain.Common;

namespace StyleVibe.Domain.Entities;

public class ProductSku : BaseEntity
{
    public string SkuCode { get; set; } = null!;
    public string Size { get; set; } = null!;
    public string Color { get; set; } = null!;
    public decimal CostPrice { get; set; }
    public decimal SellingPrice { get; set; }
    public bool IsActive { get; set; } = true;
    public byte[] RowVersion { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();
}

