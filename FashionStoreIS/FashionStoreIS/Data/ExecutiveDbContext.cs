using FashionStoreIS.Models.Executive;
using Microsoft.EntityFrameworkCore;

namespace FashionStoreIS.Data
{
    public class ExecutiveDbContext : DbContext
    {
        public ExecutiveDbContext(DbContextOptions<ExecutiveDbContext> options) : base(options)
        {
        }

        // ─── STRATEGIC KPIS ─────────────────────────────────────────────────────

        public DbSet<StrategicKpi> StrategicKpis { get; set; }
        public DbSet<KpiComparison> KpiComparisons { get; set; }

        // ─── EXTERNAL DATA ───────────────────────────────────────────────────

        public DbSet<ExternalMarketData> ExternalMarketData { get; set; }

        // ─── ALERTS AND NOTIFICATIONS ─────────────────────────────────────────

        public DbSet<ExecutiveAlert> ExecutiveAlerts { get; set; }
        public DbSet<AlertAction> AlertActions { get; set; }

        // ─── USER CONFIGURATIONS ─────────────────────────────────────────────

        public DbSet<ExecutiveUserPreference> ExecutiveUserPreferences { get; set; }
        public DbSet<AlertConfiguration> AlertConfigurations { get; set; }
        public DbSet<DashboardLayout> DashboardLayouts { get; set; }
        public DbSet<ReportSubscription> ReportSubscriptions { get; set; }

        // ─── ANALYSIS AND SCENARIOS ───────────────────────────────────────────

        public DbSet<ScenarioAnalysisResult> ScenarioAnalysisResults { get; set; }
        public DbSet<ScenarioRiskFactor> ScenarioRiskFactors { get; set; }

        // ─── COMPETITIVE INTELLIGENCE ─────────────────────────────────────────

        public DbSet<CompetitiveIntelligence> CompetitiveIntelligence { get; set; }
        public DbSet<CompetitiveAlert> CompetitiveAlerts { get; set; }

        // ─── STRATEGIC MANAGEMENT ───────────────────────────────────────────

        public DbSet<StrategicInitiative> StrategicInitiatives { get; set; }
        public DbSet<InitiativeMilestone> InitiativeMilestones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ─── STRATEGIC KPIS CONFIGURATION ─────────────────────────────────────

            modelBuilder.Entity<StrategicKpi>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.TargetValue)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.VariancePercentage)
                    .HasColumnType("decimal(5,2)");

                entity.Property(e => e.ConfidenceLevel)
                    .HasColumnType("decimal(5,2)");

                entity.HasIndex(e => new { e.KpiType, e.PeriodStart, e.PeriodEnd });
                entity.HasIndex(e => e.PeriodType);
                entity.HasIndex(e => e.IsForecast);
            });

            // ─── EXTERNAL MARKET DATA CONFIGURATION ─────────────────────────────

            modelBuilder.Entity<ExternalMarketData>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.JsonData)
                    .IsRequired();

                entity.Property(e => e.ConfidenceScore)
                    .HasColumnType("decimal(5,2)");

                entity.HasIndex(e => new { e.DataSource, e.DataType });
                entity.HasIndex(e => e.DataTimestamp);
                entity.HasIndex(e => e.ProcessedAt);
            });

            // ─── EXECUTIVE ALERTS CONFIGURATION ─────────────────────────────────

            modelBuilder.Entity<ExecutiveAlert>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Impact)
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.User)
                    .WithMany(u => u.ExecutiveAlerts)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(e => new { e.UserId, e.IsRead });
                entity.HasIndex(e => e.Category);
                entity.HasIndex(e => e.Type);
                entity.HasIndex(e => e.Priority);
                entity.HasIndex(e => e.CreatedAt);
            });

            // ─── USER PREFERENCES CONFIGURATION ─────────────────────────────────

            modelBuilder.Entity<ExecutiveUserPreference>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.UserId, e.PreferenceKey });
                entity.HasIndex(e => e.Category);
            });

            // ─── ALERT CONFIGURATIONS CONFIGURATION ─────────────────────────────

            modelBuilder.Entity<AlertConfiguration>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ThresholdValue)
                    .HasColumnType("decimal(18,2)");

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.UserId, e.AlertType });
                entity.HasIndex(e => e.IsEnabled);
            });

            // ─── DASHBOARD LAYOUTS CONFIGURATION ───────────────────────────────

            modelBuilder.Entity<DashboardLayout>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.UserId, e.DashboardType });
                entity.HasIndex(e => e.IsActive);
            });

            // ─── REPORT SUBSCRIPTIONS CONFIGURATION ─────────────────────────────

            modelBuilder.Entity<ReportSubscription>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.UserId, e.ReportType });
                entity.HasIndex(e => e.IsEnabled);
                entity.HasIndex(e => e.NextScheduled);
            });

            // ─── SCENARIO ANALYSIS RESULTS CONFIGURATION ───────────────────────

            modelBuilder.Entity<ScenarioAnalysisResult>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ConfidenceLevel)
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(e => e.CreatedByUser)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedByUserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(e => e.ScenarioType);
                entity.HasIndex(e => e.CreatedAt);
                entity.HasIndex(e => e.IsArchived);
            });

            // ─── COMPETITIVE INTELLIGENCE CONFIGURATION ─────────────────────────

            modelBuilder.Entity<CompetitiveIntelligence>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ConfidenceScore)
                    .HasColumnType("decimal(5,2)");

                entity.HasIndex(e => new { e.CompetitorName, e.DataType });
                entity.HasIndex(e => e.DataTimestamp);
                entity.HasIndex(e => e.IsVerified);
            });

            // ─── STRATEGIC INITIATIVES CONFIGURATION ───────────────────────────

            modelBuilder.Entity<StrategicInitiative>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Budget)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.ActualCost)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.ProgressPercentage)
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(e => e.OwnerUser)
                    .WithMany()
                    .HasForeignKey(e => e.OwnerUserId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasIndex(e => e.Status);
                entity.HasIndex(e => e.Priority);
                entity.HasIndex(e => e.OwnerUserId);
                entity.HasIndex(e => e.TargetDate);
            });

            // ─── SUPPORTING ENTITIES CONFIGURATION ───────────────────────────

            modelBuilder.Entity<KpiComparison>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.ComparisonValue)
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.VariancePercentage)
                    .HasColumnType("decimal(5,2)");

                entity.HasOne(e => e.StrategicKpi)
                    .WithMany(k => k.KpiComparisons)
                    .HasForeignKey(e => e.StrategicKpiId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<AlertAction>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.ExecutiveAlert)
                    .WithMany(a => a.AlertActions)
                    .HasForeignKey(e => e.ExecutiveAlertId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.TakenByUser)
                    .WithMany()
                    .HasForeignKey(e => e.TakenByUserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => new { e.ExecutiveAlertId, e.ActionAt });
            });

            modelBuilder.Entity<ScenarioRiskFactor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.ScenarioAnalysisResult)
                    .WithMany(s => s.RiskFactors)
                    .HasForeignKey(e => e.ScenarioAnalysisResultId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CompetitiveAlert>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.CompetitiveIntelligence)
                    .WithMany(c => c.CompetitiveAlerts)
                    .HasForeignKey(e => e.CompetitiveIntelligenceId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => e.IsResolved);
            });

            modelBuilder.Entity<InitiativeMilestone>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.StrategicInitiative)
                    .WithMany(s => s.Milestones)
                    .HasForeignKey(e => e.StrategicInitiativeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(e => new { e.StrategicInitiativeId, e.TargetDate });
                entity.HasIndex(e => e.Status);
            });

            // ─── GLOBAL CONFIGURATIONS ─────────────────────────────────────────

            // Configure decimal precision for all decimal properties
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(decimal) || property.ClrType == typeof(decimal?))
                    {
                        property.SetPrecision(18);
                        property.SetScale(2);
                    }
                }
            }

            // Configure string lengths
            modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.GetMaxLength() == null)
                .ToList()
                .ForEach(p => p.SetMaxLength(1000));
        }
    }
}
