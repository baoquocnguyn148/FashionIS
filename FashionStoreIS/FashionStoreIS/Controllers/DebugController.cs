using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FashionStoreIS.Controllers
{
    public class DebugController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DebugController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var model = new
            {
                IsAuthenticated = User.Identity?.IsAuthenticated ?? false,
                UserName = User.Identity?.Name,
                AuthenticatedUser = User.Identity?.IsAuthenticated == true ? 
                    await _userManager.GetUserAsync(User) : null,
                AllRoles = await _roleManager.Roles.ToListAsync(),
                UserRoles = User.Identity?.IsAuthenticated == true ? 
                    await _userManager.GetRolesAsync(await _userManager.GetUserAsync(User)) : new List<string>(),
                AllUsers = await _db.Users.ToListAsync()
            };

            return Json(model);
        }

        public async Task<IActionResult> SeedAdmin()
        {
            var adminEmail = "admin@gmail.com";
            var adminPassword = "Admin@123";
            
            // Check if admin exists
            var admin = await _userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    FullName = "Super Admin",
                    EmailConfirmed = true,
                    JoinDate = DateTime.UtcNow
                };
                
                var result = await _userManager.CreateAsync(admin, adminPassword);
                if (!result.Succeeded)
                {
                    return Json(new { success = false, errors = result.Errors });
                }
            }
            
            // Ensure SuperAdmin role exists
            var superAdminRole = await _roleManager.FindByNameAsync("SuperAdmin");
            if (superAdminRole == null)
            {
                superAdminRole = new IdentityRole("SuperAdmin");
                await _roleManager.CreateAsync(superAdminRole);
            }
            
            // Add user to SuperAdmin role
            if (!await _userManager.IsInRoleAsync(admin, "SuperAdmin"))
            {
                await _userManager.AddToRoleAsync(admin, "SuperAdmin");
            }
            
            return Json(new { 
                success = true, 
                message = "Admin user created/updated successfully",
                email = adminEmail,
                password = adminPassword
            });
        }
    }
}
