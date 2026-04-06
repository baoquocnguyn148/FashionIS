using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Models.Analytics;

namespace FashionStoreIS.Data
{
    public class AnalyticsDbContext : DbContext
    {
        public AnalyticsDbContext(DbContextOptions<AnalyticsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fact_Sales> Fact_Sales { get; set; }
        public DbSet<Dim_Date> Dim_Date { get; set; }
        public DbSet<Dim_Product> Dim_Product { get; set; }
        public DbSet<Dim_Customer> Dim_Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Financial precisions for DW facts
            modelBuilder.Entity<Fact_Sales>().Property(f => f.UnitPrice).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Fact_Sales>().Property(f => f.SalesAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Fact_Sales>().Property(f => f.DiscountAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Fact_Sales>().Property(f => f.COGS).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Fact_Sales>().Property(f => f.GrossProfit).HasColumnType("decimal(18,2)");

            // Support PostgreSQL case-insensitivity conventions
            if (Database.IsNpgsql())
            {
                foreach (var entity in modelBuilder.Model.GetEntityTypes())
                {
                    entity.SetTableName(entity.GetTableName()?.ToLower());
                    foreach (var property in entity.GetProperties())
                        property.SetColumnName(property.GetColumnName().ToLower());
                }
            }
        }
    }
}
