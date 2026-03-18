using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Oracle.EntityFrameworkCore;

namespace StyleVibe.Infrastructure.Data;

/// <summary>
/// Factory used by EF Core design-time tools (migrations) to create AppDbContext
/// without requiring the full ASP.NET Core host.
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseOracle(
            "User Id=FashionDB;Password=123;Data Source=localhost:1521/XE", 
            o => o.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19));

        return new AppDbContext(optionsBuilder.Options);
    }
}
