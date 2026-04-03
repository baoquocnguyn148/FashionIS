using FashionStoreIS.Models.Executive;

namespace FashionStoreIS.Areas.Admin.ViewModels.Executive
{
    // ─── COMPETITIVE INTELLIGENCE MODELS ─────────────────────────────────────

    public class CompetitorData
    {
        public string Name { get; set; } = string.Empty;
        public decimal MarketShare { get; set; }
        public decimal EstimatedRevenue { get; set; }
        public decimal GrowthRate { get; set; }
        public List<string> Strengths { get; set; } = new();
        public List<string> Weaknesses { get; set; } = new();
        public List<string> ProductCategories { get; set; } = new();
        public int StoreCount { get; set; }
        public decimal OnlinePresence { get; set; }
    }

    public class PriceComparisonData
    {
        public List<PriceComparisonItem> PriceComparisons { get; set; } = new();
        public string OverallPricePositioning { get; set; } = string.Empty;
        public decimal AveragePriceAdvantage { get; set; }
        public decimal PriceElasticity { get; set; }
    }

    public class ProductComparisonData
    {
        public List<ProductComparisonItem> ProductComparisons { get; set; } = new();
        public decimal OverallQualityScore { get; set; }
        public bool InnovationLeader { get; set; }
        public decimal SustainabilityScore { get; set; }
    }

    public class MarketingComparisonData
    {
        public Dictionary<string, decimal> SocialMediaPresence { get; set; } = new();
        public Dictionary<string, decimal> EngagementRates { get; set; } = new();
        public Dictionary<string, decimal> MarketingSpend { get; set; } = new();
        public Dictionary<string, decimal> BrandAwareness { get; set; } = new();
    }

    public class CompetitiveAlert
    {
        public string Type { get; set; } = string.Empty;
        public string Competitor { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Impact { get; set; } = string.Empty;
        public string RecommendedAction { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class PriceComparisonItem
    {
        public string ProductCategory { get; set; } = string.Empty;
        public decimal OurPrice { get; set; }
        public Dictionary<string, decimal> CompetitorPrices { get; set; } = new();
        public string PricePositioning { get; set; } = string.Empty;
        public decimal PriceAdvantage { get; set; }
    }

    public class ProductComparisonItem
    {
        public string ProductType { get; set; } = string.Empty;
        public List<string> OurFeatures { get; set; } = new();
        public Dictionary<string, List<string>> CompetitorFeatures { get; set; } = new();
        public decimal QualityScore { get; set; }
        public decimal InnovationScore { get; set; }
    }

    // ─── STRATEGIC MODELS ─────────────────────────────────────────────────

    public class StrategicRecommendationModel
    {
        public string RecommendationTitle { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal ImpactScore { get; set; }
        public decimal ImplementationCost { get; set; }
        public decimal ExpectedROI { get; set; }
        public int ImplementationTime { get; set; }
        public List<string> RequiredResources { get; set; } = new();
        public List<string> SuccessMetrics { get; set; } = new();
        public List<string> RiskFactors { get; set; } = new();
    }

    // ─── EXTERNAL DATA MODELS ─────────────────────────────────────────

    public class MarketTrendData
    {
        public DateTime Timestamp { get; set; }
        public decimal MarketIndex { get; set; }
        public decimal MarketChange { get; set; }
        public List<string> TrendingCategories { get; set; } = new();
        public List<string> TrendingColors { get; set; } = new();
        public decimal ConsumerSentiment { get; set; }
        public decimal FashionWeekImpact { get; set; }
    }

    public class EconomicIndicatorsModel
    {
        public EconomicIndicator GDP { get; set; } = new();
        public EconomicIndicator Inflation { get; set; } = new();
        public EconomicIndicator ConsumerConfidence { get; set; } = new();
        public EconomicIndicator RetailSales { get; set; } = new();
        public EconomicIndicator ExchangeRate { get; set; } = new();
    }

    public class EconomicIndicator
    {
        public string Name { get; set; } = string.Empty;
        public decimal CurrentValue { get; set; }
        public decimal PreviousValue { get; set; }
        public string Unit { get; set; } = string.Empty;
        public string Trend { get; set; } = string.Empty;
        public DateTime LastUpdated { get; set; }
    }

    public class EconomicIndicatorModel
    {
        public EconomicIndicator GDP { get; set; } = new();
        public EconomicIndicator Inflation { get; set; } = new();
        public EconomicIndicator ConsumerConfidence { get; set; } = new();
        public EconomicIndicator RetailSales { get; set; } = new();
        public EconomicIndicator ExchangeRate { get; set; } = new();
    }

    public class SentimentAnalysisModel
    {
        public decimal OverallSentiment { get; set; }
        public Dictionary<string, decimal> SentimentBreakdown { get; set; } = new();
        public Dictionary<string, decimal> PlatformSentiments { get; set; } = new();
        public List<string> TrendingTopics { get; set; } = new();
        public Dictionary<string, int> MentionVolume { get; set; } = new();
        public string SentimentTrend { get; set; } = string.Empty;
        public DateTime LastAnalyzed { get; set; }
    }

    public class CompetitorPriceModel
    {
        public string Competitor { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = string.Empty;
        public DateTime LastUpdated { get; set; }
        public string Url { get; set; } = string.Empty;
    }

    public class MarketTrendModel
    {
        public string Category { get; set; } = string.Empty;
        public string Trend { get; set; } = string.Empty;
        public decimal GrowthRate { get; set; }
        public decimal Confidence { get; set; }
        public int DataPoints { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class SocialMediaSentimentModel
    {
        public string Platform { get; set; } = string.Empty;
        public int Mentions { get; set; }
        public decimal PositiveSentiment { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    // ─── OPERATIONAL MODELS ─────────────────────────────────────────────

    public class DepartmentPerformanceModel
    {
        public string Department { get; set; } = string.Empty;
        public decimal EfficiencyScore { get; set; }
        public decimal ProductivityScore { get; set; }
        public decimal QualityScore { get; set; }
        public decimal InnovationScore { get; set; }
        public decimal BudgetUtilization { get; set; }
        public List<EmployeePerformance> TopPerformers { get; set; } = new();
        public List<PerformanceIssue> Issues { get; set; } = new();
    }

    public class EmployeePerformance
    {
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeId { get; set; } = string.Empty;
        public decimal PerformanceScore { get; set; }
        public int SalesVolume { get; set; }
        public decimal RevenueGenerated { get; set; }
        public decimal CustomerSatisfaction { get; set; }
        public List<string> Strengths { get; set; } = new();
        public List<string> DevelopmentAreas { get; set; } = new();
    }

    public class PerformanceIssue
    {
        public string IssueType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AffectedEmployees { get; set; }
        public decimal ImpactScore { get; set; }
        public List<string> RootCauses { get; set; } = new();
        public List<string> RecommendedActions { get; set; } = new();
    }

    // ─── OPERATIONAL MODELS ─────────────────────────────────────────────

    public class RealTimeKpiModel
    {
        public decimal CurrentRevenue { get; set; }
        public decimal DailyOrders { get; set; }
        public decimal ActiveUsers { get; set; }
        public decimal ConversionRate { get; set; }
        public decimal AverageOrderValue { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<string> Alerts { get; set; } = new();
    }

    public class ExecutiveReportModel
    {
        public string ReportType { get; set; } = string.Empty;
        public string ReportPeriod { get; set; } = string.Empty;
        public DateTime GeneratedAt { get; set; }
        public string GeneratedBy { get; set; } = string.Empty;
        public byte[] Data { get; set; } = Array.Empty<byte>();
        public string ContentType { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public List<string> Sections { get; set; } = new();
        public Dictionary<string, object> Parameters { get; set; } = new();
    }

    // ─── ADDITIONAL MODELS NEEDED ─────────────────────────────────────────

    public class PurchaseOrderDetails
    {
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string SKU { get; set; } = string.Empty;
    }

    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string SKU { get; set; } = string.Empty;
    }

    public class MonthlyTrendData
    {
        public string Month { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public decimal? Target { get; set; }
        public decimal VariancePercentage { get; set; }
    }

    public class UserPreferencesModel
    {
        public string DashboardLayout { get; set; } = string.Empty;
        public List<string> FavoriteKpis { get; set; } = new();
        public List<string> AlertPreferences { get; set; } = new();
        public string Theme { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
        public List<string> QuickActions { get; set; } = new();
        public Dictionary<string, object> CustomSettings { get; set; } = new();
    }

    public class AlertConfigurationModel
    {
        public string AlertType { get; set; } = string.Empty;
        public string MetricName { get; set; } = string.Empty;
        public string Operator { get; set; } = string.Empty;
        public decimal ThresholdValue { get; set; }
        public bool IsEnabled { get; set; }
        public string Frequency { get; set; } = string.Empty;
        public string NotificationMethod { get; set; } = string.Empty;
        public int PriorityLevel { get; set; }
    }

    public class DashboardLayoutModel
    {
        public string LayoutName { get; set; } = string.Empty;
        public List<WidgetConfiguration> Widgets { get; set; } = new();
        public string ColorScheme { get; set; } = string.Empty;
        public int RefreshInterval { get; set; }
        public List<string> VisibleSections { get; set; } = new();
    }

    public class ReportSubscriptionModel
    {
        public string ReportType { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public List<string> Recipients { get; set; } = new();
        public bool IsEnabled { get; set; }
        public DateTime? LastSent { get; set; }
        public DateTime? NextScheduled { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = new();
    }

    public class WidgetConfiguration
    {
        public string WidgetType { get; set; } = string.Empty;
        public string WidgetId { get; set; } = string.Empty;
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Dictionary<string, object> Settings { get; set; } = new();
    }

    // ─── MISSING MODELS ─────────────────────────────────────────────────

    public class MarketShareAnalysisModel
    {
        public decimal OurMarketShare { get; set; }
        public decimal MarketGrowthRate { get; set; }
        public List<CompetitorPosition> CompetitorPositions { get; set; } = new();
        public List<GeographicMarketData> GeographicMarkets { get; set; } = new();
        public List<string> GrowthOpportunities { get; set; } = new();
    }

    public class CompetitorAnalysisModel
    {
        public List<CompetitorData> Competitors { get; set; } = new();
        public string MarketPosition { get; set; } = string.Empty;
        public List<string> CompetitiveAdvantages { get; set; } = new();
        public List<string> CompetitiveThreats { get; set; } = new();
        public List<string> StrategicRecommendations { get; set; } = new();
    }

    public class TrendAnalysisModel
    {
        public List<FashionTrend> CurrentTrends { get; set; } = new();
        public List<FashionTrend> EmergingTrends { get; set; } = new();
        public List<FashionTrend> DecliningTrends { get; set; } = new();
        public List<string> KeyInsights { get; set; } = new();
        public DateTime AnalysisDate { get; set; }
    }

    public class FashionTrend
    {
        public string Name { get; set; } = string.Empty;
        public decimal GrowthRate { get; set; }
        public decimal MarketSize { get; set; }
        public decimal AdoptionRate { get; set; }
        public string ExpectedLifespan { get; set; } = string.Empty;
        public List<string> KeyDrivers { get; set; } = new();
    }

    public class CustomerInsightsModel
    {
        public int TotalCustomers { get; set; }
        public int NewCustomersThisMonth { get; set; }
        public int ActiveCustomers { get; set; }
        public decimal AverageOrderValue { get; set; }
        public decimal CustomerLifetimeValue { get; set; }
        public List<CustomerSegment> CustomerSegments { get; set; } = new();
        public List<CustomerBehavior> BehaviorPatterns { get; set; } = new();
    }

    public class CustomerSegment
    {
        public string SegmentName { get; set; } = string.Empty;
        public int CustomerCount { get; set; }
        public decimal RevenueContribution { get; set; }
        public decimal GrowthRate { get; set; }
        public List<string> Characteristics { get; set; } = new();
    }

    public class CustomerBehavior
    {
        public string BehaviorType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Percentage { get; set; }
        public List<string> Recommendations { get; set; } = new();
    }

    public class GeographicAnalysisModel
    {
        public List<GeographicMarketData> RegionalPerformance { get; set; } = new();
        public List<MarketOpportunity> ExpansionOpportunities { get; set; } = new();
        public List<LogisticsPerformance> LogisticsMetrics { get; set; } = new();
    }

    public class MarketOpportunity
    {
        public string Region { get; set; } = string.Empty;
        public string OpportunityType { get; set; } = string.Empty;
        public decimal MarketPotential { get; set; }
        public decimal InvestmentRequired { get; set; }
        public decimal ExpectedROI { get; set; }
        public List<string> RiskFactors { get; set; } = new();
    }

    public class LogisticsPerformance
    {
        public string Region { get; set; } = string.Empty;
        public decimal DeliveryTime { get; set; }
        public decimal OnTimeDeliveryRate { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal CustomerSatisfaction { get; set; }
    }

    public class ScenarioAnalysisModel
    {
        public List<PlanningScenario> Scenarios { get; set; } = new();
        public List<ScenarioAssumption> Assumptions { get; set; } = new();
        public List<ScenarioRisk> Risks { get; set; } = new();
        public List<string> Recommendations { get; set; } = new();
    }

    public class PlanningScenario
    {
        public string ScenarioName { get; set; } = string.Empty;
        public string ScenarioType { get; set; } = string.Empty;
        public Dictionary<string, decimal> Parameters { get; set; } = new();
        public Dictionary<string, decimal> Outcomes { get; set; } = new();
        public decimal Probability { get; set; }
        public List<string> KeyAssumptions { get; set; } = new();
        public List<string> TriggerEvents { get; set; } = new();
    }

    public class ScenarioAssumption
    {
        public string AssumptionName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal ConfidenceLevel { get; set; }
        public string DataSource { get; set; } = string.Empty;
        public List<string> ValidationMethods { get; set; } = new();
    }

    public class ScenarioRisk
    {
        public string RiskName { get; set; } = string.Empty;
        public string RiskCategory { get; set; } = string.Empty;
        public decimal Probability { get; set; }
        public decimal Impact { get; set; }
        public decimal RiskScore { get; set; }
        public List<string> MitigationStrategies { get; set; } = new();
    }

    public class GrowthOpportunityModel
    {
        public string OpportunityName { get; set; } = string.Empty;
        public string OpportunityType { get; set; } = string.Empty;
        public decimal MarketSize { get; set; }
        public decimal GrowthPotential { get; set; }
        public decimal InvestmentRequired { get; set; }
        public decimal ExpectedROI { get; set; }
        public int TimeToMarket { get; set; }
        public List<string> SuccessFactors { get; set; } = new();
        public List<string> RiskFactors { get; set; } = new();
    }

    public class RiskAssessmentModel
    {
        public List<BusinessRisk> Risks { get; set; } = new();
        public List<RiskMitigation> MitigationStrategies { get; set; } = new();
        public decimal OverallRiskScore { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
        public List<string> CriticalRisks { get; set; } = new();
    }

    public class BusinessRisk
    {
        public string RiskName { get; set; } = string.Empty;
        public string RiskCategory { get; set; } = string.Empty;
        public decimal Probability { get; set; }
        public decimal Impact { get; set; }
        public decimal RiskScore { get; set; }
        public string RiskLevel { get; set; } = string.Empty;
        public List<string> MitigationActions { get; set; } = new();
        public string Owner { get; set; } = string.Empty;
    }

    public class RiskMitigation
    {
        public string RiskName { get; set; } = string.Empty;
        public string MitigationStrategy { get; set; } = string.Empty;
        public decimal Effectiveness { get; set; }
        public decimal Cost { get; set; }
        public int ImplementationTime { get; set; }
        public string ResponsibleParty { get; set; } = string.Empty;
    }

    public class InvestmentAnalysisModel
    {
        public List<InvestmentOpportunity> Opportunities { get; set; } = new();
        public List<InvestmentCriteria> Criteria { get; set; } = new();
        public decimal TotalBudget { get; set; }
        public decimal AllocatedBudget { get; set; }
        public decimal AvailableBudget { get; set; }
        public List<string> Priorities { get; set; } = new();
    }

    public class InvestmentOpportunity
    {
        public string OpportunityName { get; set; } = string.Empty;
        public string InvestmentType { get; set; } = string.Empty;
        public decimal InvestmentAmount { get; set; }
        public decimal ExpectedReturn { get; set; }
        public decimal ROI { get; set; }
        public int PaybackPeriod { get; set; }
        public decimal NPV { get; set; }
        public decimal IRR { get; set; }
        public List<string> Benefits { get; set; } = new();
        public List<string> Risks { get; set; } = new();
    }

    public class InvestmentCriteria
    {
        public string CriterionName { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public decimal MinimumThreshold { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<string> EvaluationMethods { get; set; } = new();
    }

    public class InitiativeTrackingModel
    {
        public List<StrategicInitiative> Initiatives { get; set; } = new();
        public List<InitiativeMilestone> Milestones { get; set; } = new();
        public decimal OverallProgress { get; set; }
        public int CompletedInitiatives { get; set; }
        public int InProgressInitiatives { get; set; }
        public int PlannedInitiatives { get; set; }
        public List<string> Blockers { get; set; } = new();
    }

    public class StrategicInitiative
    {
        public int Id { get; set; }
        public string InitiativeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string OwnerUserId { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public decimal? Budget { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? ProgressPercentage { get; set; }
        public string SuccessCriteria { get; set; } = string.Empty;
        public string Risks { get; set; } = string.Empty;
        public string Dependencies { get; set; } = string.Empty;
    }

    public class InitiativeMilestone
    {
        public int Id { get; set; }
        public int StrategicInitiativeId { get; set; }
        public string MilestoneName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime TargetDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Deliverables { get; set; } = string.Empty;
    }

    // ─── ANALYTICS MODELS ─────────────────────────────────────────────────

    public class KpiDashboardModel
    {
        public List<StrategicKpi> StrategicKpis { get; set; } = new();
        public List<OperationalMetric> OperationalMetrics { get; set; } = new();
        public List<PerformanceTrend> Trends { get; set; } = new();
        public List<PerformanceAlert> Alerts { get; set; } = new();
    }

    public class OperationalMetric
    {
        public string MetricName { get; set; } = string.Empty;
        public decimal CurrentValue { get; set; }
        public decimal TargetValue { get; set; }
        public decimal Variance { get; set; }
        public string Trend { get; set; } = string.Empty;
        public List<string> ActionItems { get; set; } = new();
    }

    public class PerformanceTrend
    {
        public string MetricName { get; set; } = string.Empty;
        public List<TrendDataPoint> DataPoints { get; set; } = new();
        public decimal GrowthRate { get; set; }
        public string TrendDirection { get; set; } = string.Empty;
        public List<string> Insights { get; set; } = new();
    }

    public class TrendDataPoint
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public decimal? Target { get; set; }
        public string? Category { get; set; }
    }

    public class PerformanceAlert
    {
        public string AlertType { get; set; } = string.Empty;
        public string MetricName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Threshold { get; set; }
        public decimal CurrentValue { get; set; }
        public DateTime TriggeredAt { get; set; }
        public List<string> RecommendedActions { get; set; } = new();
    }

    public class BalancedScorecardModel
    {
        public FinancialPerspective Financial { get; set; } = new();
        public CustomerPerspective Customer { get; set; } = new();
        public InternalProcessPerspective InternalProcess { get; set; } = new();
        public LearningGrowthPerspective LearningGrowth { get; set; } = new();
        public decimal OverallScore { get; set; }
        public List<string> StrategicInitiatives { get; set; } = new();
    }

    public class FinancialPerspective
    {
        public decimal RevenueGrowth { get; set; }
        public decimal Profitability { get; set; }
        public decimal CostEfficiency { get; set; }
        public decimal AssetUtilization { get; set; }
        public List<FinancialObjective> Objectives { get; set; } = new();
    }

    public class CustomerPerspective
    {
        public decimal CustomerSatisfaction { get; set; }
        public decimal MarketShare { get; set; }
        public decimal CustomerRetention { get; set; }
        public decimal BrandValue { get; set; }
        public List<CustomerObjective> Objectives { get; set; } = new();
    }

    public class InternalProcessPerspective
    {
        public decimal OperationalEfficiency { get; set; }
        public decimal QualityMetrics { get; set; }
        public decimal InnovationRate { get; set; }
        public decimal SupplyChainPerformance { get; set; }
        public List<ProcessObjective> Objectives { get; set; } = new();
    }

    public class LearningGrowthPerspective
    {
        public decimal EmployeeSatisfaction { get; set; }
        public decimal SkillDevelopment { get; set; }
        public decimal KnowledgeManagement { get; set; }
        public decimal TechnologyAdoption { get; set; }
        public List<LearningObjective> Objectives { get; set; } = new();
    }

    public class FinancialObjective
    {
        public string ObjectiveName { get; set; } = string.Empty;
        public decimal Target { get; set; }
        public decimal Current { get; set; }
        public decimal Achievement { get; set; }
        public List<string> Initiatives { get; set; } = new();
    }

    public class CustomerObjective
    {
        public string ObjectiveName { get; set; } = string.Empty;
        public decimal Target { get; set; }
        public decimal Current { get; set; }
        public decimal Achievement { get; set; }
        public List<string> Initiatives { get; set; } = new();
    }

    public class ProcessObjective
    {
        public string ObjectiveName { get; set; } = string.Empty;
        public decimal Target { get; set; }
        public decimal Current { get; set; }
        public decimal Achievement { get; set; }
        public List<string> Initiatives { get; set; } = new();
    }

    public class LearningObjective
    {
        public string ObjectiveName { get; set; } = string.Empty;
        public decimal Target { get; set; }
        public decimal Current { get; set; }
        public decimal Achievement { get; set; }
        public List<string> Initiatives { get; set; } = new();
    }

    public class PerformanceTrendsModel
    {
        public List<TrendData> RevenueTrends { get; set; } = new();
        public List<TrendData> ProfitTrends { get; set; } = new();
        public List<TrendData> CustomerTrends { get; set; } = new();
        public List<TrendData> OperationalTrends { get; set; } = new();
        public List<string> KeyInsights { get; set; } = new();
    }

    public class TrendData
    {
        public string Period { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public decimal Target { get; set; }
        public decimal Variance { get; set; }
        public string Trend { get; set; } = string.Empty;
    }
}
