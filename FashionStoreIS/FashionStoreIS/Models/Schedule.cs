using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models
{
    public class Schedule : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; } = null!;
        public DateTime Date { get; set; }
        public ScheduleStatus Status { get; set; } = ScheduleStatus.Scheduled;
        public string? Note { get; set; }
    }
}
