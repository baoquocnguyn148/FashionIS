using FashionStoreIS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;

using FashionStoreIS.Models;
using FashionStoreIS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
    connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
if (string.IsNullOrWhiteSpace(connectionString))
    connectionString = builder.Configuration["ORACLE_CONNECTION_STRING"];
if (string.IsNullOrWhiteSpace(connectionString))
{
    if (!builder.Environment.IsDevelopment())
        throw new InvalidOperationException("Connection string 'DefaultConnection' not found. Set it in appsettings or ORACLE_CONNECTION_STRING env var.");

    var sqlitePath = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "fashionstore-dev.db");
    Directory.CreateDirectory(Path.GetDirectoryName(sqlitePath)!);
    var sqliteConn = $"Data Source={sqlitePath}";

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(sqliteConn));
}
else
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseOracle(connectionString));
}

var analyticsDbPath = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "DataWarehouse.db");
builder.Services.AddDbContext<AnalyticsDbContext>(options =>
    options.UseSqlite($"Data Source={analyticsDbPath}"));

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

builder.Services.AddScoped<IUserStore<ApplicationUser>, OracleCompatibleUserStore>();
builder.Services.AddScoped<IRoleStore<IdentityRole>, OracleCompatibleRoleStore>();
builder.Services.AddScoped<IVnPayService, VnPayService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<RfmSegmentationService>();
builder.Services.AddScoped<InventoryIntelligenceService>();

// Executive Support System Services
builder.Services.AddScoped<IStrategicAnalyticsService, StrategicAnalyticsService>();
builder.Services.AddScoped<IExternalDataIntegrationService, ExternalDataIntegrationService>();
builder.Services.AddScoped<IPayrollService, PayrollService>();

// Executive Database Context
var executiveDbPath = Path.Combine(builder.Environment.ContentRootPath, "App_Data", "Executive.db");
builder.Services.AddDbContext<ExecutiveDbContext>(options =>
    options.UseSqlite($"Data Source={executiveDbPath}"));

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
    
    try
    {
        await DbInitializer.Seed(context, userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database seeding error: {ex.Message}");
    }
    
    // Auto-create Analytics Data Warehouse Tables if missing
    var analyticsContext = services.GetRequiredService<AnalyticsDbContext>();
    analyticsContext.Database.EnsureCreated();
    
    // Auto-create Executive Database Tables if missing
    var executiveContext = services.GetRequiredService<ExecutiveDbContext>();
    executiveContext.Database.EnsureCreated();
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
