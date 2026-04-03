namespace FashionStoreIS.Areas.Admin.ViewModels.Executive
{
    // ─── Main Dashboard View Models ────────────────────────────────────────

    public class ExecutiveDashboardViewModel
    {
        public FinancialKpiModel FinancialKpis { get; set; } = new();
        public MarketMetricsModel MarketMetrics { get; set; } = new();
        public OperationalMetricsModel OperationalMetrics { get; set; } = new();
        public PredictiveInsightsModel PredictiveInsights { get; set; } = new();
        public CompetitiveIntelligenceModel CompetitiveIntelligence { get; set; } = new();
        public List<ExecutiveAlertModel> ExecutiveAlerts { get; set; } = new();
    }

    // ─── Financial Analysis View Models ─────────────────────────────────────

    public class FinancialAnalysisViewModel
    {
        public RevenueAnalysisModel RevenueAnalysis { get; set; } = new();
        public ProfitabilityAnalysisModel ProfitabilityAnalysis { get; set; } = new();
        public CashFlowAnalysisModel CashFlowAnalysis { get; set; } = new();
        public BudgetVarianceModel BudgetVariance { get; set; } = new();
        public FinancialForecastModel FinancialForecasts { get; set; } = new();
        public List<ProfitabilityByProduct> ProfitabilityByProducts { get; set; } = new();
    }

    // ─── Market Intelligence View Models ───────────────────────────────────

    public class MarketIntelligenceViewModel
    {
        public MarketShareAnalysisModel MarketShareAnalysis { get; set; } = new();
        public CompetitorAnalysisModel CompetitorAnalysis { get; set; } = new();
        public TrendAnalysisModel TrendAnalysis { get; set; } = new();
        public CustomerInsightsModel CustomerInsights { get; set; } = new();
        public GeographicAnalysisModel GeographicAnalysis { get; set; } = new();
    }

    // ─── Strategic Planning View Models ─────────────────────────────────────

    public class StrategicPlanningViewModel
    {
        public ScenarioAnalysisModel ScenarioAnalysis { get; set; } = new();
        public List<GrowthOpportunityModel> GrowthOpportunities { get; set; } = new();
        public RiskAssessmentModel RiskAssessment { get; set; } = new();
        public InvestmentAnalysisModel InvestmentAnalysis { get; set; } = new();
        public List<StrategicRecommendationModel> StrategicRecommendations { get; set; } = new();
    }

    // ─── Performance Monitoring View Models ─────────────────────────────────

    public class PerformanceMonitoringViewModel
    {
        public KpiDashboardModel KpiDashboard { get; set; } = new();
        public BalancedScorecardModel BalancedScorecard { get; set; } = new();
        public List<DepartmentPerformanceModel> DepartmentPerformance { get; set; } = new();
        public List<InitiativeTrackingModel> InitiativeTracking { get; set; } = new();
        public PerformanceTrendsModel PerformanceTrends { get; set; } = new();
    }

    // ─── Settings View Model ─────────────────────────────────────────────────

    public class ExecutiveSettingsViewModel
    {
        public UserPreferencesModel UserPreferences { get; set; } = new();
        public List<AlertConfigurationModel> AlertConfigurations { get; set; } = new();
        public DashboardLayoutModel DashboardLayout { get; set; } = new();
        public List<ReportSubscriptionModel> ReportSubscriptions { get; set; } = new();
    }

    // ─── Data Models ────────────────────────────────────────────────────────

    public class FinancialKpiModel
    {
        public decimal RevenueGrowthRate { get; set; }
        public decimal GrossMargin { get; set; }
        public decimal NetMargin { get; set; }
        public decimal CustomerAcquisitionCost { get; set; }
        public decimal CustomerLifetimeValue { get; set; }
        public decimal ReturnOnInvestment { get; set; }
        public decimal Ebitda { get; set; }
        public decimal WorkingCapital { get; set; }
        public List<MonthlyTrendData> RevenueTrends { get; set; } = new();
        public List<MonthlyTrendData> MarginTrends { get; set; } = new();
    }

    public class MarketMetricsModel
    {
        public decimal MarketShare { get; set; }
        public decimal MarketGrowthRate { get; set; }
        public int TotalAddressableMarket { get; set; }
        public decimal BrandAwareness { get; set; }
        public decimal CustomerSatisfaction { get; set; }
        public decimal NetPromoterScore { get; set; }
        public List<CompetitorPosition> CompetitorPositions { get; set; } = new();
        public List<GeographicMarketData> GeographicMarkets { get; set; } = new();
    }

    public class OperationalMetricsModel
    {
        public decimal InventoryTurnover { get; set; }
        public decimal SupplyChainEfficiency { get; set; }
        public decimal EmployeeProductivity { get; set; }
        public decimal DigitalTransformationRate { get; set; }
        public decimal AutomationLevel { get; set; }
        public int OnTimeDeliveryRate { get; set; }
        public decimal QualityScore { get; set; }
        public List<DepartmentMetric> DepartmentMetrics { get; set; } = new();
    }

    public class PredictiveInsightsModel
    {
        public SalesForecastModel SalesForecast { get; set; } = new();
        public ChurnPredictionModel ChurnPrediction { get; set; } = new();
        public DemandForecastModel DemandForecast { get; set; } = new();
        public MarketTrendPredictionModel MarketTrends { get; set; } = new();
        public List<PredictiveAlert> PredictiveAlerts { get; set; } = new();
    }

    public class CompetitiveIntelligenceModel
    {
        public List<CompetitorData> Competitors { get; set; } = new();
        public PriceComparisonData PriceComparison { get; set; } = new();
        public ProductComparisonData ProductComparison { get; set; } = new();
        public MarketingComparisonData MarketingComparison { get; set; } = new();
        public List<CompetitiveAlert> CompetitiveAlerts { get; set; } = new();
    }

    public class ExecutiveAlertModel
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty; // Critical, Warning, Opportunity
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? Impact { get; set; }
        public string ActionRequired { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public string Category { get; set; } = string.Empty; // Financial, Market, Operational, Strategic
    }

    // ─── Supporting Data Models ─────────────────────────────────────────────

    public class DepartmentMetric
    {
        public string Department { get; set; } = string.Empty;
        public decimal Efficiency { get; set; }
        public decimal Productivity { get; set; }
        public decimal BudgetUtilization { get; set; }
        public int EmployeeCount { get; set; }
        public decimal PerformanceScore { get; set; }
    }

    // ─── Request/Response Models ────────────────────────────────────────────

    public class ScenarioRequest
    {
        public string ScenarioType { get; set; } = string.Empty; // Price, Market, Investment
        public Dictionary<string, decimal> Parameters { get; set; } = new();
        public int TimeHorizonMonths { get; set; }
        public List<string> AffectedMetrics { get; set; } = new();
    }

    public class ScenarioAnalysisResult
    {
        public string ScenarioName { get; set; } = string.Empty;
        public Dictionary<string, decimal> ImpactAnalysis { get; set; } = new();
        public List<string> Recommendations { get; set; } = new();
        public decimal ConfidenceLevel { get; set; }
        public List<RiskFactor> RiskFactors { get; set; } = new();
    }

    // ─── Extended Data Models for Detailed Analysis ─────────────────────────

    public class RevenueAnalysisModel
    {
        public decimal TotalRevenue { get; set; }
        public decimal YearOverYearGrowth { get; set; }
        public decimal MonthOverMonthGrowth { get; set; }
        public List<RevenueByCategory> RevenueByCategories { get; set; } = new();
        public List<RevenueByChannel> RevenueByChannels { get; set; } = new();
        public List<RevenueByRegion> RevenueByRegions { get; set; } = new();
    }

    public class ProfitabilityAnalysisModel
    {
        public decimal GrossProfit { get; set; }
        public decimal GrossMargin { get; set; }
        public decimal OperatingProfit { get; set; }
        public decimal OperatingMargin { get; set; }
        public decimal NetProfit { get; set; }
        public decimal NetMargin { get; set; }
        public decimal EbitdaMargin { get; set; }
        public List<ProfitabilityByProduct> ProfitabilityByProducts { get; set; } = new();
    }

    public class CashFlowAnalysisModel
    {
        public decimal OperatingCashFlow { get; set; }
        public decimal InvestingCashFlow { get; set; }
        public decimal FinancingCashFlow { get; set; }
        public decimal NetCashFlow { get; set; }
        public decimal CashBalance { get; set; }
        public List<MonthlyCashFlow> MonthlyCashFlows { get; set; } = new();
    }

    public class BudgetVarianceModel
    {
        public decimal TotalBudget { get; set; }
        public decimal ActualSpending { get; set; }
        public decimal Variance { get; set; }
        public decimal VariancePercentage { get; set; }
        public List<BudgetVarianceByDepartment> DepartmentVariances { get; set; } = new();
    }

    public class FinancialForecastModel
    {
        public List<MonthlyForecast> RevenueForecasts { get; set; } = new();
        public List<MonthlyForecast> ExpenseForecasts { get; set; } = new();
        public List<MonthlyForecast> ProfitForecasts { get; set; } = new();
        public decimal ConfidenceLevel { get; set; }
        public List<string> Assumptions { get; set; } = new();
    }

    // ─── Additional Supporting Models ───────────────────────────────────────

    public class RevenueByCategory
    {
        public string Category { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public decimal Growth { get; set; }
        public decimal PercentageOfTotal { get; set; }
    }

    public class RevenueByChannel
    {
        public string Channel { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public decimal Growth { get; set; }
        public decimal PercentageOfTotal { get; set; }
    }

    public class RevenueByRegion
    {
        public string Region { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
        public decimal Growth { get; set; }
        public decimal PercentageOfTotal { get; set; }
    }

    public class MonthlyCashFlow
    {
        public string Month { get; set; } = string.Empty;
        public decimal Operating { get; set; }
        public decimal Investing { get; set; }
        public decimal Financing { get; set; }
        public decimal Net { get; set; }
    }

    public class BudgetVarianceByDepartment
    {
        public string Department { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        public decimal Actual { get; set; }
        public decimal Variance { get; set; }
        public decimal VariancePercentage { get; set; }
    }
}
