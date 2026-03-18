using System.Collections.Generic;

namespace FashionStoreIS.Models
{
    public class ProductSku : BaseEntity
    {
        public string SKU { get; set; } = null!;
        public string SkuCode { get; set; } = null!; // Keep for compatibility if needed
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal? PriceOverride { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; } = true;

        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
