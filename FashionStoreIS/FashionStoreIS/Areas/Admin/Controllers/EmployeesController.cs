using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/Employees
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Store)
                .ToListAsync();
            return View(employees);
        }

        // GET: Admin/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Store)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (employee == null) return NotFound();

            return View(employee);
        }

        // GET: Admin/Employees/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.IsActive), "Id", "Name");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name");
            
            // Get users who are NOT yet employees
            var existingEmployeeUserIds = await _context.Employees
                .Where(e => e.UserId != null)
                .Select(e => e.UserId)
                .ToListAsync();

            var users = await _userManager.Users
                .Where(u => !existingEmployeeUserIds.Contains(u.Id))
                .ToListAsync();

            ViewData["UserId"] = new SelectList(users, "Id", "Email");
            
            return View();
        }

        // POST: Admin/Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,Phone,Email,Position,HireDate,IsActive,BaseSalaryPerHour,BankAccountNumber,BankName,BankAccountName,DepartmentId,UserId,StoreId")] Employee employee)
        {
            // Remove navigation properties from validation as they are not provided by the form
            ModelState.Remove("Department");
            ModelState.Remove("Store");

            if (ModelState.IsValid)
            {
                employee.CreatedAt = DateTime.Now;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm mới nhân viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.IsActive), "Id", "Name", employee.DepartmentId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", employee.StoreId);
            
            // Re-load users for the dropdown
            var existingEmployeeUserIds = await _context.Employees
                .Where(e => e.UserId != null)
                .Select(e => e.UserId)
                .ToListAsync();

            var users = await _userManager.Users
                .Where(u => !existingEmployeeUserIds.Contains(u.Id))
                .ToListAsync();

            ViewData["UserId"] = new SelectList(users, "Id", "Email", employee.UserId);

            return View(employee);
        }

        // GET: Admin/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.IsActive), "Id", "Name", employee.DepartmentId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", employee.StoreId);
            return View(employee);
        }

        // POST: Admin/Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Phone,Email,Position,HireDate,IsActive,BaseSalaryPerHour,BankAccountNumber,BankName,BankAccountName,DepartmentId,UserId,StoreId,CreatedAt")] Employee employee)
        {
            if (id != employee.Id) return NotFound();

            // Remove navigation properties from validation
            ModelState.Remove("Department");
            ModelState.Remove("Store");

            if (ModelState.IsValid)
            {
                try
                {
                    employee.UpdatedAt = DateTime.Now;
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Cập nhật thông tin nhân viên thành công!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Employees.Any(e => e.Id == employee.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments.Where(d => d.IsActive), "Id", "Name", employee.DepartmentId);
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name", employee.StoreId);
            return View(employee);
        }
    }
}
