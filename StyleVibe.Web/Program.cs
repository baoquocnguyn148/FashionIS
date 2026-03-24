using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using StyleVibe.Application.Interfaces;
using StyleVibe.Application.Services;
using StyleVibe.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });
builder.Services.AddRazorPages(); // Cho Identity UI

// Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? builder.Configuration.GetConnectionString("StyleVibeConnection")
    ?? "User Id=YOUR_USER;Password=YOUR_PASSWORD;Data Source=localhost:1521/YOUR_SERVICE";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(connectionString,
        o => o.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19)));

// Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbContext>();

// DI
builder.Services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
builder.Services.AddScoped<IPosService, PosService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();

// Session (cho cart server-side sau này)
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Seed roles + admin user khi khởi động
await SeedRolesAsync(app);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthentication(); // PHẢI trước UseAuthorization
app.UseAuthorization();
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
   .WithStaticAssets();
app.MapRazorPages(); // Cho Identity Login/Register pages

app.Run();

// Seed Roles và Admin user
static async Task SeedRolesAsync(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    // Tạo roles nếu chưa có
    foreach (var role in new[] { "Admin", "Staff", "Customer" })
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    // Tạo tài khoản admin mặc định nếu chưa có
    var adminEmail = "admin@gmail.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        adminUser = new IdentityUser {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };
        var result = await userManager.CreateAsync(adminUser, "Admin@123");
        if (result.Succeeded)
            await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}
