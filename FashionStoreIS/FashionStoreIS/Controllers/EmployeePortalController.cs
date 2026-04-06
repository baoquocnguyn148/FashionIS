using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using FashionStoreIS.ViewModels.EmployeePortal;
using Microsoft.AspNetCore.Authorization;

namespace FashionStoreIS.Controllers
{
    [Authorize(Roles = "Staff,SuperAdmin")]
    public class EmployeePortalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeePortalController(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<Employee?> GetCurrentEmployee()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId)) return null;

            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Store)
                .FirstOrDefaultAsync(e => e.UserId == userId);
        }

        public async Task<IActionResult> Index()
        {
            var employee = await GetCurrentEmployee();
            if (employee == null) return Content("Access Restricted: No Employee Profile linked to this Account.");

            var model = new PortalDashboardViewModel
            {
                Employee = employee,
                LeaveBalance = await _context.LeaveBalances.FirstOrDefaultAsync(lb => lb.EmployeeId == employee.Id && lb.Year == DateTime.Now.Year),
                NextShift = await _context.Schedules.Include(s => s.Shift).Where(s => s.EmployeeId == employee.Id && s.Date >= DateTime.Today).OrderBy(s => s.Date).FirstOrDefaultAsync(),
                TodayAttendance = await _context.Attendances.FirstOrDefaultAsync(a => a.EmployeeId == employee.Id && a.Date == DateTime.Today),
                RecentHistory = await _context.Attendances.Where(a => a.EmployeeId == employee.Id).OrderByDescending(a => a.Date).Take(5).ToListAsync(),
                PendingLeaves = await _context.LeaveRequests.Where(l => l.EmployeeId == employee.Id && l.Status == LeaveStatus.Pending).ToListAsync()
            };

            return View(model);
        }

        public async Task<IActionResult> Schedules()
        {
            var employee = await GetCurrentEmployee();
            if (employee == null) return NotFound();

            var monday = GetMonday(DateTime.Now);
            var sunday = monday.AddDays(13);

            var schedules = await _context.Schedules
                .Include(s => s.Shift)
                .Where(s => s.EmployeeId == employee.Id && s.Date >= monday && s.Date <= sunday)
                .OrderBy(s => s.Date)
                .ToListAsync();

            var model = new PortalScheduleViewModel
            {
                ThisWeek = schedules.Where(s => s.Date < monday.AddDays(7)).ToList(),
                NextWeek = schedules.Where(s => s.Date >= monday.AddDays(7)).ToList(),
                WeekStart = monday
            };

            return View(model);
        }

        public async Task<IActionResult> Leave()
        {
            var employee = await GetCurrentEmployee();
            if (employee == null) return NotFound();

            var model = new PortalLeaveViewModel
            {
                Balance = await _context.LeaveBalances.FirstOrDefaultAsync(lb => lb.EmployeeId == employee.Id && lb.Year == DateTime.Now.Year),
                Requests = await _context.LeaveRequests.Where(l => l.EmployeeId == employee.Id).OrderByDescending(l => l.CreatedAt).ToListAsync(),
                NewRequest = new LeaveRequest { EmployeeId = employee.Id, StartDate = DateTime.Today, EndDate = DateTime.Today }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestLeave(PortalLeaveViewModel model)
        {
            if (ModelState.IsValid)
            {
                var request = model.NewRequest;
                request.Status = LeaveStatus.Pending;
                request.CreatedAt = DateTime.Now;
                _context.LeaveRequests.Add(request);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã gửi đơn nghỉ phép thành công.";
                return RedirectToAction(nameof(Leave));
            }
            return RedirectToAction(nameof(Leave));
        }

        public async Task<IActionResult> Payroll()
        {
            var employee = await GetCurrentEmployee();
            if (employee == null) return NotFound();

            var payrolls = await _context.Payrolls
                .Where(p => p.EmployeeId == employee.Id)
                .OrderByDescending(p => p.Year)
                .ThenByDescending(p => p.Month)
                .ToListAsync();

            return View(payrolls);
        }

        public async Task<IActionResult> PayrollDetail(int id)
        {
            var employee = await GetCurrentEmployee();
            if (employee == null) return NotFound();

            var payroll = await _context.Payrolls
                .Include(p => p.Items)
                .ThenInclude(i => i.SalaryComponent)
                .FirstOrDefaultAsync(p => p.Id == id && p.EmployeeId == employee.Id);

            if (payroll == null) return NotFound();

            return View(payroll);
        }

        public async Task<IActionResult> Profile()
        {
            var employee = await GetCurrentEmployee();
            if (employee == null) return NotFound();

            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn()
        {
            var employee = await GetCurrentEmployee();
            if (employee == null) return Json(new { success = false, message = "Không tìm thấy hồ sơ nhân viên." });

            var today = DateTime.Today;
            var existing = await _context.Attendances.FirstOrDefaultAsync(a => a.EmployeeId == employee.Id && a.Date == today);

            if (existing != null)
                return Json(new { success = false, message = "Bạn đã chấm công vào hôm nay rồi." });

            var attendance = new Attendance
            {
                EmployeeId = employee.Id,
                Date = today,
                CheckIn = DateTime.Now.TimeOfDay,
                Status = AttendanceStatus.Present,
                CreatedAt = DateTime.Now
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return Json(new { success = true, checkInTime = attendance.CheckIn.Value.ToString(@"hh\:mm") });
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut()
        {
            var employee = await GetCurrentEmployee();
            if (employee == null) return Json(new { success = false, message = "Không tìm thấy hồ sơ nhân viên." });

            var today = DateTime.Today;
            var attendance = await _context.Attendances.FirstOrDefaultAsync(a => a.EmployeeId == employee.Id && a.Date == today);

            if (attendance == null)
                return Json(new { success = false, message = "Bạn chưa chấm công vào hôm nay." });

            if (attendance.CheckOut.HasValue)
                return Json(new { success = false, message = "Bạn đã chấm công ra hôm nay rồi." });

            attendance.CheckOut = DateTime.Now.TimeOfDay;
            attendance.TotalHours = Math.Round((attendance.CheckOut.Value - attendance.CheckIn.Value).TotalHours, 2);
            attendance.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Json(new { success = true, checkOutTime = attendance.CheckOut.Value.ToString(@"hh\:mm"), totalHours = attendance.TotalHours });
        }

        private DateTime GetMonday(DateTime dt)
        {
            int diff = (7 + (dt.Date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.Date.AddDays(-1 * diff).Date;
        }
    }
}
