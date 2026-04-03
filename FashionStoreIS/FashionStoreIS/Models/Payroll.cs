using System;
using System.Collections.Generic;

namespace FashionStoreIS.Models
{
    public class Payroll : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;

        public int Month { get; set; }
        public int Year { get; set; }

        public double TotalHoursWorked { get; set; }
        public decimal BaseHourlyRate { get; set; }
        
        /// <summary>
        /// (TotalHoursWorked * BaseHourlyRate)
        /// </summary>
        public decimal TotalBaseSalary { get; set; }
        
        public decimal TotalAdditions { get; set; }
        public decimal TotalDeductions { get; set; }
        public decimal NetSalary { get; set; } // TotalBaseSalary + TotalAdditions - TotalDeductions

        public PayrollStatus Status { get; set; } = PayrollStatus.Draft;
        public DateTime? ProcessedDate { get; set; }
        public string? Note { get; set; }

        public virtual ICollection<PayrollItem> Items { get; set; } = new HashSet<PayrollItem>();
    }
}
