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

            // 1. Calculate Total Working Hours from Attendance
            var totalHours = await _context.Attendances
                .Where(a => a.EmployeeId == employeeId && a.Date.Month == month && a.Date.Year == year)
                .SumAsync(a => a.TotalHours);

            // 2. Base Calculation
            var baseHourlyRate = employee.BaseSalaryPerHour;
            var totalBaseSalary = (decimal)totalHours * baseHourlyRate;

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

            // 4. Add Default Salary Components (e.g. Lunch Allowance, Insurance)
            var activeComponents = await _context.SalaryComponents
                .Where(c => c.IsActive)
                .ToListAsync();

            decimal additions = 0;
            decimal deductions = 0;

            foreach (var comp in activeComponents)
            {
                var item = new PayrollItem
                {
                    SalaryComponentId = comp.Id,
                    Amount = comp.DefaultAmount,
                    Note = comp.Name
                };

                payroll.Items.Add(item);

                if (comp.Type == SalaryComponentType.Addition)
                    additions += comp.DefaultAmount;
                else
                    deductions += comp.DefaultAmount;
            }

            payroll.TotalAdditions = additions;
            payroll.TotalDeductions = deductions;
            payroll.NetSalary = totalBaseSalary + additions - deductions;

            return payroll;
        }

        public async Task<IEnumerable<Payroll>> GenerateAllPayrollsAsync(int month, int year)
        {
            var activeEmployees = await _context.Employees
                .Where(e => e.IsActive)
                .ToListAsync();

            var payrolls = new List<Payroll>();

            foreach (var emp in activeEmployees)
            {
                // Check if payroll already exists for this month
                var existing = await _context.Payrolls
                    .AnyAsync(p => p.EmployeeId == emp.Id && p.Month == month && p.Year == year);

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
    }
}
