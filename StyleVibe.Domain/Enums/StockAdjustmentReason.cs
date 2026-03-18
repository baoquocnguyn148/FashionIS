namespace StyleVibe.Domain.Enums;

public enum StockAdjustmentReason : byte
{
    PurchaseOrder = 1,
    SaleReturn = 2,
    Transfer = 3,
    Damage = 4,
    Manual = 5
}

