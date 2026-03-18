using FashionStoreIS.Models;

namespace FashionStoreIS.Areas.Admin.ViewModels
{
    public class DashboardViewModel
    {
        // Statistics Cards
        public decimal TotalRevenue { get; set; }
        public int TotalOrders { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalProducts { get; set; }

        // Chart Data
        public List<MonthlyRevenueData> MonthlyRevenueData { get; set; } = new();
        public List<OrderStatusData> OrderStatusData { get; set; } = new();

        // Top Lists
        public List<TopProductData> TopProducts { get; set; } = new();
        public List<TopCustomerData> TopCustomers { get; set; } = new();
    }

    public class MonthlyRevenueData
    {
        public string Month { get; set; } = "";
        public decimal Revenue { get; set; }
    }

    public class OrderStatusData
    {
        public string Status { get; set; } = "";
        public int Count { get; set; }
    }

    public class TopProductData
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public string ImageUrl { get; set; } = "";
        public int TotalQuantity { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class TopCustomerData
    {
        public string CustomerName { get; set; } = "";
        public string Phone { get; set; } = "";
        public int OrderCount { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
