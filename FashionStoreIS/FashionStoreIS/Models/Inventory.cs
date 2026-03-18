using System;
using System.Collections.Generic;

namespace FashionStoreIS.Models
{
    public class Inventory : BaseEntity
    {
        public int QuantityOnHand { get; set; }
        public int ReorderPoint { get; set; } = 10;
        public int? MaxStockLevel { get; set; } = 200;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

        public int StoreId { get; set; }
        public virtual Store Store { get; set; } = null!;

        public int ProductSkuId { get; set; }
        public virtual ProductSku ProductSku { get; set; } = null!;

        public virtual ICollection<StockAdjustment> StockAdjustments { get; set; } = new List<StockAdjustment>();
    }
}
