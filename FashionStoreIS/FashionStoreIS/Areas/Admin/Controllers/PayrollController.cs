using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models;
using FashionStoreIS.Services;
using Microsoft.AspNetCore.Authorization;

namespace FashionStoreIS.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class PayrollController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPayrollService _payrollService;

        public PayrollController(ApplicationDbContext context, IPayrollService payrollService)
        {
            _context = context;
            _payrollService = payrollService;
        }

        // GET: Admin/Payroll
        public async Task<IActionResult> Index(int? month, int? year)
        {
            var filterMonth = month ?? DateTime.Now.Month;
            var filterYear = year ?? DateTime.Now.Year;

            ViewData["FilterMonth"] = filterMonth;
            ViewData["FilterYear"] = filterYear;

            var payrolls = await _context.Payrolls
                .Include(p => p.Employee)
                .Where(p => p.Month == filterMonth && p.Year == filterYear)
                .ToListAsync();

            return View(payrolls);
        }

        // POST: Admin/Payroll/Generate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Generate(int month, int year)
        {
            try
            {
                await _payrollService.GenerateAllPayrollsAsync(month, year);
                TempData["Success"] = "Bảng lương cho tháng " + month + "/" + year + " đã được tạo thành công.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Lỗi khi tạo bảng lương: " + ex.Message;
            }
            return RedirectToAction(nameof(Index), new { month, year });
        }

        // GET: Admin/Payroll/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var payroll = await _context.Payrolls
                .Include(p => p.Employee)
                .Include(p => p.Items)
                .ThenInclude(i => i.SalaryComponent)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (payroll == null) return NotFound();

            return View(payroll);
        }

        // POST: Admin/Payroll/ProcessPayment/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProcessPayment(int id)
        {
            var result = await _payrollService.ProcessPaymentAsync(id);
            if (result)
            {
                TempData["Success"] = "Đã xác nhận thanh toán lương cho nhân viên.";
            }
            else
            {
                TempData["Error"] = "Không thể xử lý thanh toán bảng lương.";
            }

            var payroll = await _context.Payrolls.FindAsync(id);
            return RedirectToAction(nameof(Index), new { month = payroll?.Month, year = payroll?.Year });
        }
    }
}
