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
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class LeaveRequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LeaveRequestController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Admin/LeaveRequest
        public async Task<IActionResult> Index(LeaveStatus? status, int? month)
        {
            var query = _context.LeaveRequests.Include(l => l.Employee).AsQueryable();
            if (status.HasValue)
                query = query.Where(l => l.Status == status);
            if (month.HasValue)
                query = query.Where(l => l.StartDate.Month == month);

            ViewData["Status"] = status;
            ViewData["Month"] = month;
            return View(await query.OrderByDescending(l => l.CreatedAt).ToListAsync());
        }

        // GET: Admin/LeaveRequest/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees.Where(e => e.IsActive), "Id", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                leaveRequest.Status = LeaveStatus.Pending;
                leaveRequest.CreatedAt = DateTime.Now;
                _context.Add(leaveRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees.Where(e => e.IsActive), "Id", "FullName", leaveRequest.EmployeeId);
            return View(leaveRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null) return NotFound();

            leave.Status = LeaveStatus.Approved;
            leave.ApprovedById = _userManager.GetUserId(User);
            leave.UpdatedAt = DateTime.Now;

            // Update LeaveBalance
            var balance = await _context.LeaveBalances.FirstOrDefaultAsync(b => b.EmployeeId == leave.EmployeeId && b.Year == leave.StartDate.Year);
            if (balance == null)
            {
                balance = new LeaveBalance { EmployeeId = leave.EmployeeId, Year = leave.StartDate.Year, CreatedAt = DateTime.Now };
                _context.LeaveBalances.Add(balance);
            }

            int days = (leave.EndDate - leave.StartDate).Days + 1;
            if (leave.Type == LeaveType.Annual) balance.AnnualDaysUsed += days;
            else if (leave.Type == LeaveType.Sick) balance.SickDaysUsed += days;

            await _context.SaveChangesAsync();
            TempData["Success"] = "Đã phê duyệt đơn nghỉ phép.";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id, string adminNote)
        {
            var leave = await _context.LeaveRequests.FindAsync(id);
            if (leave == null) return NotFound();

            leave.Status = LeaveStatus.Rejected;
            leave.AdminNote = adminNote;
            leave.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
            TempData["Success"] = "Đã từ chối đơn nghỉ phép.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Balance(int employeeId)
        {
            var balance = await _context.LeaveBalances.Where(b => b.EmployeeId == employeeId && b.Year == DateTime.Now.Year).FirstOrDefaultAsync();
            if (balance == null) return NotFound("Chưa có dữ liệu ngày phép cho nhân viên này.");
            return Ok(balance);
        }
    }
}
