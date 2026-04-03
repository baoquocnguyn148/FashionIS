using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models.Executive
{
    // ─── STRATEGIC KPIS TABLE ─────────────────────────────────────────────────

    [Table("StrategicKpis")]
    public class StrategicKpi : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string KpiType { get; set; } = string.Empty; // Revenue, MarketShare, CAC, CLV, etc.

        [Required]
        [StringLength(20)]
        public string PeriodType { get; set; } = string.Empty; // Daily, Weekly, Monthly, Quarterly, Yearly

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TargetValue { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal VariancePercentage { get; set; }

        [Required]
        public DateTime PeriodStart { get; set; }

        [Required]
        public DateTime PeriodEnd { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        [StringLength(50)]
        public string? DataSource { get; set; } // Internal, External, API, Manual

        public decimal? ConfidenceLevel { get; set; } // For forecasted KPIs

        public bool IsForecast { get; set; } = false;

        // Navigation properties
        public virtual ICollection<KpiComparison> KpiComparisons { get; set; } = new List<KpiComparison>();
    }

    // ─── EXTERNAL MARKET DATA CACHE ───────────────────────────────────────────

    [Table("ExternalMarketData")]
    public class ExternalMarketData : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string DataSource { get; set; } = string.Empty; // CompetitorAPI, EconomicAPI, SocialAPI, etc.

        [Required]
        [StringLength(50)]
        public string DataType { get; set; } = string.Empty; // Price, Sentiment, Trend, Economic

        [Required]
        public string JsonData { get; set; } = string.Empty;

        [Required]
        public DateTime DataTimestamp { get; set; }

        [Required]
        public DateTime ProcessedAt { get; set; }

        [StringLength(20)]
        public string? Currency { get; set; }

        [StringLength(10)]
        public string? Region { get; set; }

        public bool IsValidated { get; set; } = false;

        public decimal? ConfidenceScore { get; set; }

        [StringLength(500)]
        public string? ProcessingNotes { get; set; }
    }

    // ─── EXECUTIVE ALERTS ───────────────────────────────────────────────────

    [Table("ExecutiveAlerts")]
    public class ExecutiveAlert : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Type { get; set; } = string.Empty; // Critical, Warning, Opportunity, Info

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Impact { get; set; }

        [StringLength(500)]
        public string? ActionRequired { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty; // Financial, Market, Operational, Strategic

        [StringLength(50)]
        public string? SubCategory { get; set; }

        [StringLength(450)]
        public string? UserId { get; set; } // Target specific executive, null for all

        public bool IsRead { get; set; } = false;

        public DateTime? ReadAt { get; set; }

        [StringLength(50)]
        public string? Priority { get; set; } // High, Medium, Low

        public DateTime? ExpiresAt { get; set; }

        public bool IsArchived { get; set; } = false;

        [StringLength(100)]
        public string? SourceSystem { get; set; }

        // Navigation properties
        public virtual ApplicationUser? User { get; set; }
        public virtual ICollection<AlertAction> AlertActions { get; set; } = new List<AlertAction>();
    }

    // ─── USER PREFERENCES ────────────────────────────────────────────────────

    [Table("ExecutiveUserPreferences")]
    public class ExecutiveUserPreference : BaseEntity
    {
        [Required]
        [StringLength(450)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string PreferenceKey { get; set; } = string.Empty;

        public string PreferenceValue { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Category { get; set; } // Dashboard, Alerts, Reports, etc.

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ApplicationUser User { get; set; } = null!;
    }

    // ─── ALERT CONFIGURATIONS ───────────────────────────────────────────────

    [Table("AlertConfigurations")]
    public class AlertConfiguration : BaseEntity
    {
        [Required]
        [StringLength(450)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string AlertType { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string MetricName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Operator { get; set; } // >, <, >=, <=, =, !=

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ThresholdValue { get; set; }

        public bool IsEnabled { get; set; } = true;

        [StringLength(20)]
        public string? Frequency { get; set; } // Real-time, Daily, Weekly, Monthly

        [StringLength(500)]
        public string? NotificationMethod { get; set; } // Email, SMS, Dashboard, All

        public int? PriorityLevel { get; set; } // 1=High, 2=Medium, 3=Low

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ApplicationUser User { get; set; } = null!;
    }

    // ─── DASHBOARD LAYOUTS ───────────────────────────────────────────────────

    [Table("DashboardLayouts")]
    public class DashboardLayout : BaseEntity
    {
        [Required]
        [StringLength(450)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string DashboardType { get; set; } = string.Empty; // Strategic, Financial, Market, etc.

        public string LayoutConfig { get; set; } = string.Empty; // JSON configuration

        [StringLength(50)]
        public string? Theme { get; set; }

        public bool IsDefault { get; set; } = false;

        public bool IsActive { get; set; } = true;

        public int? DisplayOrder { get; set; }

        // Navigation properties
        public virtual ApplicationUser User { get; set; } = null!;
    }

    // ─── REPORT SUBSCRIPTIONS ───────────────────────────────────────────────

    [Table("ReportSubscriptions")]
    public class ReportSubscription : BaseEntity
    {
        [Required]
        [StringLength(450)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string ReportType { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Frequency { get; set; } = string.Empty; // Daily, Weekly, Monthly, Quarterly

        [StringLength(20)]
        public string? Format { get; set; } // PDF, Excel, CSV, Email

        [Required]
        [StringLength(500)]
        public string Recipients { get; set; } = string.Empty; // Comma-separated emails

        public bool IsEnabled { get; set; } = true;

        public DateTime? LastSent { get; set; }

        public DateTime? NextScheduled { get; set; }

        [StringLength(500)]
        public string? Parameters { get; set; } // JSON parameters for report generation

        // Navigation properties
        public virtual ApplicationUser User { get; set; } = null!;
    }

    // ─── SCENARIO ANALYSIS RESULTS ───────────────────────────────────────────

    [Table("ScenarioAnalysisResults")]
    public class ScenarioAnalysisResult : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string ScenarioName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string ScenarioType { get; set; } = string.Empty; // Price, Market, Investment

        public string InputParameters { get; set; } = string.Empty; // JSON

        public string ImpactAnalysis { get; set; } = string.Empty; // JSON

        public string Recommendations { get; set; } = string.Empty; // JSON

        [Column(TypeName = "decimal(5,2)")]
        public decimal ConfidenceLevel { get; set; }

        [StringLength(450)]
        public string? CreatedByUserId { get; set; }

        public int TimeHorizonMonths { get; set; }

        [StringLength(500)]
        public string? Assumptions { get; set; }

        [StringLength(500)]
        public string? Limitations { get; set; }

        public bool IsArchived { get; set; } = false;

        // Navigation properties
        public virtual ApplicationUser? CreatedByUser { get; set; }
        public virtual ICollection<ScenarioRiskFactor> RiskFactors { get; set; } = new List<ScenarioRiskFactor>();
    }

    // ─── COMPETITIVE INTELLIGENCE ────────────────────────────────────────────

    [Table("CompetitiveIntelligence")]
    public class CompetitiveIntelligence : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string CompetitorName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string DataType { get; set; } = string.Empty; // Price, Product, Marketing, Financial

        public string DataContent { get; set; } = string.Empty; // JSON

        [Required]
        public DateTime DataTimestamp { get; set; }

        [StringLength(100)]
        public string? Source { get; set; }

        [StringLength(20)]
        public string? Region { get; set; }

        public decimal? ConfidenceScore { get; set; }

        public bool IsVerified { get; set; } = false;

        [StringLength(500)]
        public string? Analysis { get; set; }

        // Navigation properties
        public virtual ICollection<CompetitiveAlert> CompetitiveAlerts { get; set; } = new List<CompetitiveAlert>();
    }

    // ─── STRATEGIC INITIATIVES ───────────────────────────────────────────────

    [Table("StrategicInitiatives")]
    public class StrategicInitiative : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string InitiativeName { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = string.Empty; // Planning, InProgress, Completed, Cancelled

        [StringLength(50)]
        public string? Priority { get; set; } // High, Medium, Low

        [StringLength(450)]
        public string? OwnerUserId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? TargetDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Budget { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? ActualCost { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? ProgressPercentage { get; set; }

        [StringLength(500)]
        public string? SuccessCriteria { get; set; }

        [StringLength(500)]
        public string? Risks { get; set; }

        [StringLength(500)]
        public string? Dependencies { get; set; }

        // Navigation properties
        public virtual ApplicationUser? OwnerUser { get; set; }
        public virtual ICollection<InitiativeMilestone> Milestones { get; set; } = new List<InitiativeMilestone>();
    }

    // ─── SUPPORTING ENTITIES ─────────────────────────────────────────────────

    [Table("KpiComparisons")]
    public class KpiComparison : BaseEntity
    {
        [Required]
        public int StrategicKpiId { get; set; }

        [Required]
        [StringLength(100)]
        public string ComparisonType { get; set; } = string.Empty; // PreviousPeriod, Target, Competitor, Industry

        [Column(TypeName = "decimal(18,2)")]
        public decimal ComparisonValue { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal VariancePercentage { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        // Navigation properties
        public virtual StrategicKpi StrategicKpi { get; set; } = null!;
    }

    [Table("AlertActions")]
    public class AlertAction : BaseEntity
    {
        [Required]
        public int ExecutiveAlertId { get; set; }

        [Required]
        [StringLength(100)]
        public string ActionType { get; set; } = string.Empty; // Acknowledged, Resolved, Escalated, Dismissed

        [Required]
        [StringLength(450)]
        public string TakenByUserId { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ActionNotes { get; set; }

        [Required]
        public DateTime ActionAt { get; set; }

        // Navigation properties
        public virtual ExecutiveAlert ExecutiveAlert { get; set; } = null!;
        public virtual ApplicationUser TakenByUser { get; set; } = null!;
    }

    [Table("ScenarioRiskFactors")]
    public class ScenarioRiskFactor : BaseEntity
    {
        [Required]
        public int ScenarioAnalysisResultId { get; set; }

        [Required]
        [StringLength(200)]
        public string RiskDescription { get; set; } = string.Empty;

        [StringLength(50)]
        public string? RiskCategory { get; set; } // Market, Financial, Operational, Regulatory

        [StringLength(20)]
        public string? ImpactLevel { get; set; } // High, Medium, Low

        [StringLength(20)]
        public string? Probability { get; set; } // High, Medium, Low

        [StringLength(500)]
        public string? MitigationStrategy { get; set; }

        // Navigation properties
        public virtual ScenarioAnalysisResult ScenarioAnalysisResult { get; set; } = null!;
    }

    [Table("CompetitiveAlerts")]
    public class CompetitiveAlert : BaseEntity
    {
        [Required]
        public int CompetitiveIntelligenceId { get; set; }

        [Required]
        [StringLength(100)]
        public string AlertType { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Impact { get; set; }

        [StringLength(500)]
        public string? RecommendedAction { get; set; }

        public bool IsResolved { get; set; } = false;

        public DateTime? ResolvedAt { get; set; }

        // Navigation properties
        public virtual CompetitiveIntelligence CompetitiveIntelligence { get; set; } = null!;
    }

    [Table("InitiativeMilestones")]
    public class InitiativeMilestone : BaseEntity
    {
        [Required]
        public int StrategicInitiativeId { get; set; }

        [Required]
        [StringLength(200)]
        public string MilestoneName { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime TargetDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        [StringLength(50)]
        public string? Status { get; set; } // Pending, Completed, Overdue

        [StringLength(500)]
        public string? Deliverables { get; set; }

        // Navigation properties
        public virtual StrategicInitiative StrategicInitiative { get; set; } = null!;
    }
}
