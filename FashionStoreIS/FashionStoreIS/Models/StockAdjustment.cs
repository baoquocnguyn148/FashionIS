namespace FashionStoreIS.Models
{
    public class StockAdjustment : BaseEntity
    {
        public int QuantityBefore { get; set; }
        public int QuantityChange { get; set; }
        public int QuantityAfter { get; set; }
        public StockAdjustmentReason Reason { get; set; }
        public string? Note { get; set; }
        public string? AdjustedByUserId { get; set; }

        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; } = null!;
    }
}
