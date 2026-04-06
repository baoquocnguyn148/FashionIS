using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models
{
    public class LeaveBalance : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public int Year { get; set; }
        public int AnnualDaysTotal { get; set; } = 12;
        public int AnnualDaysUsed { get; set; } = 0;
        public int SickDaysTotal { get; set; } = 5;
        public int SickDaysUsed { get; set; } = 0;
        
        [NotMapped]
        public int AnnualDaysRemaining => AnnualDaysTotal - AnnualDaysUsed;
    }
}
