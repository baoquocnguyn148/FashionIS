using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using FashionStoreIS.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Schedules
        public async Task<IActionResult> Index(int? storeId, DateTime? weekStart)
        {
            // Default to Monday of current week
            DateTime start = weekStart ?? GetMonday(DateTime.Now);
            DateTime end = start.AddDays(6);

            var stores = await _context.Stores.ToListAsync();
            int selectedStoreId = storeId ?? (stores.FirstOrDefault()?.Id ?? 0);

            var employees = await _context.Employees
                .Where(e => e.StoreId == selectedStoreId && e.IsActive && !e.IsDeleted)
                .ToListAsync();

            var schedules = await _context.Schedules
                .Include(s => s.Shift)
                .Where(s => s.Date >= start && s.Date <= end && s.Employee.StoreId == selectedStoreId)
                .ToListAsync();

            var viewModel = new List<ScheduleWeekViewModel>();
            foreach (var emp in employees)
            {
                var row = new ScheduleWeekViewModel
                {
                    EmployeeId = emp.Id,
                    EmployeeName = emp.FullName,
                    Position = emp.Position,
                    Days = new List<ScheduleWeekViewModel.DaySchedule>()
                };

                for (int i = 0; i < 7; i++)
                {
                    var date = start.AddDays(i);
                    var sched = schedules.FirstOrDefault(s => s.EmployeeId == emp.Id && s.Date.Date == date.Date);
                    row.Days.Add(new ScheduleWeekViewModel.DaySchedule
                    {
                        Date = date,
                        ScheduleId = sched?.Id,
                        ShiftName = sched?.Shift.Name,
                        ShiftTime = sched != null ? $"{sched.Shift.StartTime:hh\\:mm} - {sched.Shift.EndTime:hh\\:mm}" : null,
                        Status = sched?.Status
                    });
                }
                viewModel.Add(row);
            }

            ViewData["Stores"] = new SelectList(stores, "Id", "Name", selectedStoreId);
            ViewData["Shifts"] = await _context.Shifts.Where(s => s.StoreId == selectedStoreId && s.IsActive).ToListAsync();
            ViewData["WeekStart"] = start;
            ViewData["StoreId"] = selectedStoreId;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Assign(int employeeId, int shiftId, DateTime date)
        {
            // Remove existing schedule for that day if any
            var existing = await _context.Schedules.FirstOrDefaultAsync(s => s.EmployeeId == employeeId && s.Date.Date == date.Date);
            if (existing != null) _context.Schedules.Remove(existing);

            var schedule = new Schedule
            {
                EmployeeId = employeeId,
                ShiftId = shiftId,
                Date = date.Date,
                Status = ScheduleStatus.Scheduled,
                CreatedAt = DateTime.Now
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, scheduleId = schedule.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var sched = await _context.Schedules.FindAsync(id);
            if (sched == null) return NotFound();

            _context.Schedules.Remove(sched);
            await _context.SaveChangesAsync();
            return Ok(new { success = true });
        }

        private DateTime GetMonday(DateTime dt)
        {
            int diff = (7 + (dt.Date.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.Date.AddDays(-1 * diff).Date;
        }
    }
}
