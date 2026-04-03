using System.Threading.Tasks;
using FashionStoreIS.Models;
using System.Collections.Generic;

namespace FashionStoreIS.Services
{
    public interface IPayrollService
    {
        Task<Payroll> CalculateMonthlyPayrollAsync(int employeeId, int month, int year);
        Task<IEnumerable<Payroll>> GenerateAllPayrollsAsync(int month, int year);
        Task<bool> ProcessPaymentAsync(int payrollId);
    }
}
