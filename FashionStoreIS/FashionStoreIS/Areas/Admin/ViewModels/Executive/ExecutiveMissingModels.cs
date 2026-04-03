using FashionStoreIS.Models.Executive;

namespace FashionStoreIS.Areas.Admin.ViewModels.Executive
{
    // ─── MISSING MODELS FOR EXECUTIVE VIEWMODELS ─────────────────────

    public class SalesForecastModel
    {
        public List<MonthlyForecast> MonthlyForecasts { get; set; } = new();
        public decimal ConfidenceLevel { get; set; }
        public string Methodology { get; set; } = string.Empty;
    }

    public class ChurnPredictionModel
    {
        public List<AtRiskCustomer> AtRiskCustomers { get; set; } = new();
        public List<LostCustomer> LostCustomers { get; set; } = new();
        public double OverallChurnRate { get; set; }
        public decimal PredictionAccuracy { get; set; }
    }

    public class DemandForecastModel
    {
        public List<ProductDemandForecast> ProductDemandForecasts { get; set; } = new();
        public string ForecastPeriod { get; set; } = string.Empty;
        public string Methodology { get; set; } = string.Empty;
    }

    public class AtRiskCustomer
    {
        public string CustomerId { get; set; } = string.Empty;
        public int DaysSinceLastOrder { get; set; }
        public DateTime LastOrderDate { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public double ChurnProbability { get; set; }
    }

    public class LostCustomer
    {
        public string CustomerId { get; set; } = string.Empty;
        public int DaysSinceLastOrder { get; set; }
        public DateTime LastOrderDate { get; set; }
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
    }

    public class ProductDemandForecast
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CurrentStock { get; set; }
        public decimal ForecastDemand { get; set; }
        public decimal RecommendedStock { get; set; }
        public decimal ReorderPoint { get; set; }
        public decimal Confidence { get; set; }
    }

    public class PredictiveAlert
    {
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Confidence { get; set; }
        public string RecommendedAction { get; set; } = string.Empty;
    }

    public class MonthlyForecast
    {
        public string Month { get; set; } = string.Empty;
        public decimal Forecast { get; set; }
        public decimal LowerBound { get; set; }
        public decimal UpperBound { get; set; }
        public decimal Confidence { get; set; }
    }

    public class MarketTrendPredictionModel
    {
        public string TrendName { get; set; } = string.Empty;
        public string TrendDirection { get; set; } = string.Empty;
        public decimal Confidence { get; set; }
        public List<string> KeyFactors { get; set; } = new();
        public DateTime PredictionDate { get; set; }
        public List<string> Recommendations { get; set; } = new();
    }

    public class ProfitabilityByProduct
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public decimal Cost { get; set; }
        public decimal Profit { get; set; }
        public decimal Margin { get; set; }
        public int UnitsSold { get; set; }
    }

    public class RiskFactor
    {
        public string RiskName { get; set; } = string.Empty;
        public string RiskCategory { get; set; } = string.Empty;
        public string Impact { get; set; } = string.Empty;
        public decimal Probability { get; set; }
        public List<string> MitigationStrategies { get; set; } = new();
    }

    public class GeographicMarketData
    {
        public string Region { get; set; } = string.Empty;
        public decimal MarketShare { get; set; }
        public decimal Revenue { get; set; }
        public decimal GrowthRate { get; set; }
        public int CustomerCount { get; set; }
        public decimal MarketPotential { get; set; }
    }

    public class CompetitorPosition
    {
        public string CompetitorName { get; set; } = string.Empty;
        public decimal MarketShare { get; set; }
        public decimal Revenue { get; set; }
        public decimal GrowthRate { get; set; }
        public List<string> Strengths { get; set; } = new();
        public List<string> Weaknesses { get; set; } = new();
    }
}
