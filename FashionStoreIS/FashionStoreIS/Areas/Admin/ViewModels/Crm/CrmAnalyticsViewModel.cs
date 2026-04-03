using FashionStoreIS.Services;

namespace FashionStoreIS.Areas.Admin.ViewModels.Crm
{
    public class CrmAnalyticsViewModel
    {
        // Acquisition
        public int NewCustomers30Days  { get; set; }
        public int NewCustomers90Days  { get; set; }
        public int TotalCustomers      { get; set; }

        // Retention
        public int RepeatCustomers     { get; set; }   // Customers with >1 order
        public double RepeatRate       => TotalCustomers > 0 ? (double)RepeatCustomers / TotalCustomers * 100 : 0;

        // Value
        public decimal AvgClv          { get; set; }   // Avg lifetime value
        public decimal TotalRevenue    { get; set; }

        // Churn Risk
        public int AtRiskCount         { get; set; }
        public int LostCount           { get; set; }

        // Tier Distribution
        public int BronzeCount         { get; set; }
        public int SilverCount         { get; set; }
        public int GoldCount           { get; set; }
        public int VipCount            { get; set; }

        // Segment Distribution (for donut chart)
        public Dictionary<string, int> SegmentCounts { get; set; } = new();

        // Monthly new customers trend (last 6 months)
        public List<MonthlyCustomerData> MonthlyNewCustomers { get; set; } = new();

        // Top VIP customers
        public List<CustomerRfmSummary> TopVipCustomers { get; set; } = new();

        // Campaign stats
        public int TotalCampaigns      { get; set; }
        public int SentCampaigns       { get; set; }
    }

    public class MonthlyCustomerData
    {
        public string Month    { get; set; } = "";
        public int Count       { get; set; }
    }
}
