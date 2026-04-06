using System;
using System.Collections.Generic;
using FashionStoreIS.Models;

namespace FashionStoreIS.Areas.Admin.ViewModels
{
    public class ScheduleWeekViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string Position { get; set; } = null!;
        public List<DaySchedule> Days { get; set; } = new();
        
        public class DaySchedule
        {
            public DateTime Date { get; set; }
            public int? ScheduleId { get; set; }
            public string? ShiftName { get; set; }
            public string? ShiftTime { get; set; }      // "08:00 - 17:00"
            public ScheduleStatus? Status { get; set; }
        }
    }
}
