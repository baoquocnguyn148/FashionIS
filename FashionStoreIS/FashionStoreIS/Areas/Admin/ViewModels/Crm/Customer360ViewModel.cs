using FashionStoreIS.Models;
using FashionStoreIS.Services;

namespace FashionStoreIS.Areas.Admin.ViewModels.Crm
{
    public class Customer360ViewModel
    {
        // Identity
        public ApplicationUser User { get; set; } = null!;

        // Purchase Analytics
        public int TotalOrders         { get; set; }
        public decimal TotalSpent      { get; set; }
        public decimal AvgOrderValue   { get; set; }
        public DateTime? FirstOrderDate { get; set; }
        public DateTime? LastOrderDate  { get; set; }
        public int DaysSinceLastOrder  { get; set; }

        // Loyalty
        public CustomerTier Tier       { get; set; } = CustomerTier.Bronze;
        public int LoyaltyPoints       { get; set; }
        public List<LoyaltyTransaction> PointHistory { get; set; } = new();

        // Orders & Returns
        public List<Order> RecentOrders        { get; set; } = new();
        public List<ReturnRequest> Returns     { get; set; } = new();
        public List<UserAddress> Addresses     { get; set; } = new();

        // Notifications sent to this user
        public List<Notification> NotificationHistory { get; set; } = new();
        public int UnreadNotifications { get; set; }

        // RFM Segmentation
        public string RfmSegment      { get; set; } = "Others";
        public string SegmentLabel    { get; set; } = "";
        public string SegmentColor    { get; set; } = "#94a3b8";

        // Order stats
        public int CompletedOrders    { get; set; }
        public int CancelledOrders    { get; set; }
        public int PendingOrders      { get; set; }
        public int ReturnedOrders     { get; set; }
    }
}
