using FashionStoreIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


using FashionStoreIS.Models;
using FashionStoreIS.Services;

// Enable legacy timestamp behavior for compatibility with existing local DateTime usages
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Ensure the app listens on the PORT provided by Render
var port = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(port))
{
    builder.WebHost.UseUrls($"http://0.0.0.0:{port}");
}

// ─── Database Contexts Registration ─────────────────────────────────────
// Priority order: Render env vars → appsettings → null
var rawPostgres = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING")
                ?? Environment.GetEnvironmentVariable("DATABASE_URL")
                ?? builder.Configuration["POSTGRES_CONNECTION_STRING"]
                ?? builder.Configuration.GetConnectionString("PostgresConnection");

var rawAnalytics = Environment.GetEnvironmentVariable("ANALYTICS_CONNECTION_STRING")
                 ?? Environment.GetEnvironmentVariable("DATABASE_URL")
                 ?? builder.Configuration["ANALYTICS_CONNECTION_STRING"]
                 ?? builder.Configuration.GetConnectionString("AnalyticsConnection");

var postgresConnectionString = ParseRenderConnectionString(rawPostgres);
var analyticsConnectionString = ParseRenderConnectionString(rawAnalytics);

if (!string.IsNullOrWhiteSpace(postgresConnectionString))
{
    // Use Postgres for primary application data
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(postgresConnectionString));

    // Use Postgres for analytics and executive data if configured, otherwise use separate Postgres DBs
    builder.Services.AddDbContext<AnalyticsDbContext>(options =>
        options.UseNpgsql(analyticsConnectionString ?? postgresConnectionString));
    
    builder.Services.AddDbContext<ExecutiveDbContext>(options =>
        options.UseNpgsql(analyticsConnectionString ?? postgresConnectionString));
}
else
{
    // Primary Application Db (SQLite fallback)
    if (!builder.Environment.IsDevelopment())
        throw new InvalidOperationException("No connection string found. Set 'POSTGRES_CONNECTION_STRING'.");

    var sqlitePath = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "fashionstore-dev.db");
    Directory.CreateDirectory(Path.GetDirectoryName(sqlitePath)!);
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite($"Data Source={sqlitePath}"));

    // Secondary Db fallbacks (SQLite)
    var analyticsDbPath = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "DataWarehouse.db");
    builder.Services.AddDbContext<AnalyticsDbContext>(options =>
        options.UseSqlite($"Data Source={analyticsDbPath}"));

    var executiveDbPath = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "Executive.db");
    builder.Services.AddDbContext<ExecutiveDbContext>(options =>
        options.UseSqlite($"Data Source={executiveDbPath}"));
}

builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
})
    .AddRoles<IdentityRole>()
    .AddErrorDescriber<VietnameseIdentityErrorDescriber>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddScoped<IVnPayService, VnPayService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<RfmSegmentationService>();
builder.Services.AddScoped<InventoryIntelligenceService>();

// Executive Support System Services
builder.Services.AddScoped<IStrategicAnalyticsService, StrategicAnalyticsService>();
builder.Services.AddScoped<IExternalDataIntegrationService, ExternalDataIntegrationService>();
builder.Services.AddScoped<IPayrollService, PayrollService>();

// Executive Support System Services already handled in conditional block above

builder.Services.AddControllersWithViews();

// Session for Admin auth
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHostedService<EtlDataSyncService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Seed Database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    
    // Auto-create/Migrate Database Tables
    var analyticsContext = services.GetRequiredService<AnalyticsDbContext>();
    var executiveContext = services.GetRequiredService<ExecutiveDbContext>();
    
    if (context.Database.IsNpgsql())
    {
        await context.Database.MigrateAsync();
        await analyticsContext.Database.MigrateAsync();
        await executiveContext.Database.MigrateAsync();
    }
    else
    {
        context.Database.EnsureCreated();
        analyticsContext.Database.EnsureCreated();
        executiveContext.Database.EnsureCreated();
    }

    try
    {
        await DbInitializer.Seed(context, userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database seeding error: {ex.Message}");
    }
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();


app.Run();

// ─── Helper Methods ──────────────────────────────────────────────────────
// Converts postgres:// or postgresql:// URI → Npgsql Key-Value format
// Returns null if input is null/empty (so IsNullOrWhiteSpace check works correctly)
static string? ParseRenderConnectionString(string? connectionUri)
{
    if (string.IsNullOrEmpty(connectionUri))
        return null;

    // Already in Key-Value format (Host=...)
    if (!connectionUri.StartsWith("postgres://") && !connectionUri.StartsWith("postgresql://"))
        return connectionUri;

    try
    {
        var uri = new Uri(connectionUri);
        var userInfo = uri.UserInfo.Split(':');
        var user = Uri.UnescapeDataString(userInfo[0]);
        var password = userInfo.Length > 1 ? Uri.UnescapeDataString(userInfo[1]) : "";
        var host = uri.Host;
        var port = uri.Port > 0 ? uri.Port : 5432;
        var database = uri.AbsolutePath.TrimStart('/');

        return $"Host={host};Port={port};Database={database};Username={user};Password={password};SSL Mode=Require;Trust Server Certificate=true";
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[DB] Failed to parse connection URI: {ex.Message}");
        return null;
    }
}
