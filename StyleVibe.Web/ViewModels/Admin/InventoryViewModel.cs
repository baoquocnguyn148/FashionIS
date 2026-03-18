using System.ComponentModel.DataAnnotations;
using StyleVibe.Domain.Enums;

namespace StyleVibe.Web.ViewModels.Admin;

public class InventoryFilterViewModel
{
    public int? StoreId { get; set; }
    public bool LowStock { get; set; }
    public int Page { get; set; } = 1;
}

public class StockAdjustViewModel
{
    public int InventoryId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn SKU")]
    public int ProductSkuId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn cửa hàng")]
    public int StoreId { get; set; }

    [Required]
    public int QuantityChange { get; set; }

    [Required]
    public StockAdjustmentReason Reason { get; set; }

    [MaxLength(200)]
    public string? Note { get; set; }
    
    public int QuantityOnHand { get; set; }
    public string? SkuCode { get; set; }
    public string? ProductName { get; set; }
    public string? StoreName { get; set; }
}

public class PurchaseOrderViewModel
{
    [Required]
    public int SupplierId { get; set; }
    
    [Required]
    public int StoreId { get; set; }
    
    public string? Note { get; set; }
    
    public List<PurchaseOrderItemViewModel> Items { get; set; } = new();
}

public class PurchaseOrderItemViewModel
{
    public int ProductSkuId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
}
