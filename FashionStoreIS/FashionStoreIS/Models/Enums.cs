namespace FashionStoreIS.Models
{
    public enum OrderStatus : byte
    {
        Pending = 1,
        Confirmed = 2,
        Processing = 3,
        Shipped = 4,
        Completed = 5,
        Cancelled = 6,
        Returned = 7
    }

    public enum PaymentMethod : byte
    {
        Cash = 1,
        BankTransfer = 2,
        EWallet = 3,
        Card = 4
    }

    public enum PaymentStatus : byte
    {
        Unpaid = 1,
        Paid = 2,
        Refunded = 3
    }

    public enum StockAdjustmentReason : byte
    {
        PurchaseOrder = 1,
        SaleReturn = 2,
        Transfer = 3,
        Damage = 4,
        Manual = 5
    }

    public enum CustomerTier : byte
    {
        Bronze = 1,
        Silver = 2,
        Gold = 3,
        Vip = 4
    }

    public enum PurchaseOrderStatus : byte
    {
        Draft = 1,
        Sent = 2,
        Confirmed = 3,
        Received = 4,
        Cancelled = 5
    }

    public enum AttendanceStatus : byte
    {
        Present = 1,
        Late = 2,
        Absent = 3,
        HalfDay = 4
    }

    public enum LeaveType : byte
    {
        Annual = 1,
        Sick = 2,
        Personal = 3,
        Unpaid = 4
    }

    public enum LeaveStatus : byte
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }

    public enum PayrollStatus : byte
    {
        Draft = 1,
        Processed = 2,
        Paid = 3,
        Cancelled = 4
    }

    public enum SalaryComponentType : byte
    {
        Addition = 1,
        Deduction = 2
    }
}
