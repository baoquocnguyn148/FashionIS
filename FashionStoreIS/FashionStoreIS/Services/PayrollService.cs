using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FashionStoreIS.Data;
using FashionStoreIS.Models;

namespace FashionStoreIS.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly ApplicationDbContext _context;

        public PayrollService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Payroll> CalculateMonthlyPayrollAsync(int employeeId, int month, int year)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null) throw new ArgumentException("Employee not found");

            // 1. Calculate Total Working Hours & OT from Attendance
            var attendances = await _context.Attendances
                .Where(a => a.EmployeeId == employeeId && a.Date.Month == month && a.Date.Year == year)
                .ToListAsync();

            double totalHours = attendances.Sum(a => a.TotalHours);
            double otHours = attendances.Where(a => a.TotalHours > 8).Sum(a => a.TotalHours - 8);

            // 2. Base Calculation
            var baseHourlyRate = employee.BaseSalaryPerHour;
            var totalBaseSalary = (decimal)totalHours * baseHourlyRate;
            var otPay = (decimal)otHours * baseHourlyRate * 0.5m; // Add 0.5x on top of regular rate

            // 3. Setup Payroll Record
            var payroll = new Payroll
            {
                EmployeeId = employeeId,
                Month = month,
                Year = year,
                TotalHoursWorked = totalHours,
                BaseHourlyRate = baseHourlyRate,
                TotalBaseSalary = totalBaseSalary,
                Status = PayrollStatus.Draft,
                Items = new List<PayrollItem>()
            };

            if (otPay > 0)
            {
                payroll.Items.Add(new PayrollItem { Amount = otPay, Note = $"Tăng ca (OT): {otHours:N1} giờ" });
            }

            // 4. KPI Bonus
            var kpi = await _context.KpiReviews
                .Where(k => k.EmployeeId == employeeId && k.Month == month && k.Year == year)
                .FirstOrDefaultAsync();
            
            decimal kpiBonus = 0;
            if (kpi != null)
            {
                decimal multiplier = kpi.Rank switch
                {
                    KpiRank.A => 0.15m,
                    KpiRank.B => 0.08m,
                    KpiRank.C => 0.00m,
                    KpiRank.D => -0.05m,
                    _ => 0
                };
                kpiBonus = totalBaseSalary * multiplier;
                payroll.Items.Add(new PayrollItem { Amount = kpiBonus, Note = $"Thưởng/Phạt KPI (Hạng {kpi.Rank})" });
            }

            // 5. Setup Allowances & Deductions
            var activeComponents = await _context.SalaryComponents.Where(c => c.IsActive).ToListAsync();
            decimal additions = otPay + (kpiBonus > 0 ? kpiBonus : 0);
            decimal deductions = (kpiBonus < 0 ? -kpiBonus : 0);

            foreach (var comp in activeComponents)
            {
                var item = new PayrollItem { SalaryComponentId = comp.Id, Amount = comp.DefaultAmount, Note = comp.Name };
                payroll.Items.Add(item);
                if (comp.Type == SalaryComponentType.Addition) additions += comp.DefaultAmount;
                else deductions += comp.DefaultAmount;
            }

            payroll.TotalAdditions = additions;
            payroll.TotalDeductions = deductions;
            payroll.NetSalary = totalBaseSalary + additions - deductions;

            return payroll;
        }

        public async Task<IEnumerable<Payroll>> GenerateAllPayrollsAsync(int month, int year)
        {
            var activeEmployees = await _context.Employees.Where(e => e.IsActive && !e.IsDeleted).ToListAsync();
            var payrolls = new List<Payroll>();
            foreach (var emp in activeEmployees)
            {
                var existing = await _context.Payrolls.AnyAsync(p => p.EmployeeId == emp.Id && p.Month == month && p.Year == year);
                if (!existing)
                {
                    var payroll = await CalculateMonthlyPayrollAsync(emp.Id, month, year);
                    _context.Payrolls.Add(payroll);
                    payrolls.Add(payroll);
                }
            }
            await _context.SaveChangesAsync();
            return payrolls;
        }

        public async Task<bool> ProcessPaymentAsync(int payrollId)
        {
            var payroll = await _context.Payrolls.FindAsync(payrollId);
            if (payroll == null) return false;
            payroll.Status = PayrollStatus.Paid;
            payroll.ProcessedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<object> GetMonthSummaryAsync(int storeId, int month, int year)
        {
            var query = _context.Payrolls.Include(p => p.Employee)
                .Where(p => p.Month == month && p.Year == year);
            if (storeId > 0)
                query = query.Where(p => p.Employee.StoreId == storeId);

            var list = await query.ToListAsync();
            return new {
                TotalEmployees = list.Count,
                TotalGross = list.Sum(p => p.TotalBaseSalary + p.TotalAdditions),
                TotalNet = list.Sum(p => p.NetSalary),
                TotalDeductions = list.Sum(p => p.TotalDeductions)
            };
        }

        public async Task<byte[]> ExportPayrollExcelAsync(int month, int year, int? storeId)
        {
            var query = _context.Payrolls.Include(p => p.Employee).ThenInclude(e => e.Department)
                .Where(p => p.Month == month && p.Year == year);
            if (storeId.HasValue) query = query.Where(p => p.Employee.StoreId == storeId);

            var payrolls = await query.ToListAsync();

            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add($"Payroll_{month}_{year}");
                worksheet.Cell(1, 1).Value = "Nhân viên";
                worksheet.Cell(1, 2).Value = "Phòng ban";
                worksheet.Cell(1, 3).Value = "Tổng giờ";
                worksheet.Cell(1, 4).Value = "Lương cơ bản";
                worksheet.Cell(1, 5).Value = "Phụ cấp/Thưởng";
                worksheet.Cell(1, 6).Value = "Khấu trừ";
                worksheet.Cell(1, 7).Value = "Thực lĩnh";

                for (int i = 0; i < payrolls.Count; i++)
                {
                    var p = payrolls[i];
                    worksheet.Cell(i + 2, 1).Value = p.Employee.FullName;
                    worksheet.Cell(i + 2, 2).Value = p.Employee.Department?.Name ?? "";
                    worksheet.Cell(i + 2, 3).Value = p.TotalHoursWorked;
                    worksheet.Cell(i + 2, 4).Value = p.TotalBaseSalary;
                    worksheet.Cell(i + 2, 5).Value = p.TotalAdditions;
                    worksheet.Cell(i + 2, 6).Value = p.TotalDeductions;
                    worksheet.Cell(i + 2, 7).Value = p.NetSalary;
                }

                using (var stream = new System.IO.MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
