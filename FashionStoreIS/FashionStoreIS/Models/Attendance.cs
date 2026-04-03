using System;

namespace FashionStoreIS.Models
{
    public class Attendance : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;

        public DateTime Date { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        
        /// <summary>
        /// Total working hours for this day. 
        /// (CheckOut - CheckIn) minus breaks if applicable.
        /// </summary>
        public double TotalHours { get; set; }
        
        public AttendanceStatus Status { get; set; }
        public string? Note { get; set; }
    }
}
