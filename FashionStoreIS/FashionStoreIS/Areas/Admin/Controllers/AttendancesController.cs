using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using Microsoft.AspNetCore.Authorization;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin,Staff")]
    public class AttendancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Attendances
        public async Task<IActionResult> Index(DateTime? date)
        {
            var filterDate = date ?? DateTime.Today;
            ViewData["FilterDate"] = filterDate.ToString("yyyy-MM-dd");

            var attendances = await _context.Attendances
                .Include(a => a.Employee)
                .Where(a => a.Date.Date == filterDate.Date)
                .ToListAsync();

            return View(attendances);
        }

        // GET: Admin/Attendances/MonthView?month=&year=&storeId=
        public async Task<IActionResult> MonthView(int? month, int? year, int? storeId)
        {
            int m = month ?? DateTime.Now.Month;
            int y = year ?? DateTime.Now.Year;
            
            var query = _context.Attendances
                .Include(a => a.Employee)
                .Where(a => a.Date.Month == m && a.Date.Year == y);

            if (storeId.HasValue)
                query = query.Where(a => a.Employee.StoreId == storeId);

            var attendances = await query.ToListAsync();
            var grouped = attendances.GroupBy(a => a.Employee).ToList();

            ViewData["Month"] = m;
            ViewData["Year"] = y;
            ViewData["StoreId"] = storeId;
            ViewData["Stores"] = new SelectList(_context.Stores, "Id", "Name", storeId);

            return View(grouped);
        }

        // GET: Admin/Attendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var attendance = await _context.Attendances.Include(a => a.Employee).FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null) return NotFound();

            return View(attendance);
        }

        // POST: Admin/Attendances/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,Date,CheckIn,CheckOut,Status,Note")] Attendance attendance)
        {
            if (id != attendance.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    if (attendance.CheckIn.HasValue && attendance.CheckOut.HasValue)
                    {
                        var duration = attendance.CheckOut.Value - attendance.CheckIn.Value;
                        attendance.TotalHours = duration.TotalHours > 0 ? duration.TotalHours : 0;
                    }
                    attendance.UpdatedAt = DateTime.Now;
                    _context.Update(attendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Attendances.Any(e => e.Id == attendance.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index), new { date = attendance.Date.ToString("yyyy-MM-dd") });
            }
            return View(attendance);
        }

        // GET: Admin/Attendances/MonthSummary?month=&year=&storeId=
        public async Task<IActionResult> MonthSummary(int? month, int? year, int? storeId)
        {
            int m = month ?? DateTime.Now.Month;
            int y = year ?? DateTime.Now.Year;

            var employees = await _context.Employees.Where(e => !e.IsDeleted && (!storeId.HasValue || e.StoreId == storeId)).ToListAsync();
            var attendances = await _context.Attendances
                .Where(a => a.Date.Month == m && a.Date.Year == y)
                .ToListAsync();

            var summary = employees.Select(e => {
                var empAtt = attendances.Where(a => a.EmployeeId == e.Id).ToList();
                return new {
                    EmployeeName = e.FullName,
                    WorkDays = empAtt.Count(a => a.Status == AttendanceStatus.Present || a.Status == AttendanceStatus.Late),
                    TotalHours = empAtt.Sum(a => a.TotalHours),
                    LateDays = empAtt.Count(a => a.Status == AttendanceStatus.Late),
                    AbsentDays = empAtt.Count(a => a.Status == AttendanceStatus.Absent)
                };
            }).ToList();

            ViewData["Month"] = m;
            ViewData["Year"] = y;
            return View(summary);
        }

        // GET: Admin/Attendances/CheckIn
        public IActionResult CheckIn()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees.Where(e => e.IsActive), "Id", "FullName");
            return View();
        }

        // POST: Admin/Attendances/CheckIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckIn(Attendance attendance)
        {
            // Set default date to today 
            attendance.Date = DateTime.Today;
            attendance.CheckIn = DateTime.Now.TimeOfDay;
            attendance.Status = AttendanceStatus.Present;

            if (ModelState.IsValid)
            {
                _context.Add(attendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees.Where(e => e.IsActive), "Id", "FullName", attendance.EmployeeId);
            return View(attendance);
        }

        // POST: Admin/Attendances/CheckOut/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckOut(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance == null) return NotFound();

            attendance.CheckOut = DateTime.Now.TimeOfDay;
            
            // Calculate Total Hours
            if (attendance.CheckIn.HasValue)
            {
                var duration = attendance.CheckOut.Value - attendance.CheckIn.Value;
                attendance.TotalHours = duration.TotalHours;
            }

            _context.Update(attendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Attendances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var attendance = await _context.Attendances
                .Include(a => a.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attendance == null) return NotFound();

            return View(attendance);
        }

        // POST: Admin/Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
