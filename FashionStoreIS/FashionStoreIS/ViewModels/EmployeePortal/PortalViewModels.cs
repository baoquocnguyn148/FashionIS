using System;
using System.Collections.Generic;
using FashionStoreIS.Models;

namespace FashionStoreIS.ViewModels.EmployeePortal
{
    public class PortalDashboardViewModel
    {
        public Employee Employee { get; set; } = null!;
        public Schedule? NextShift { get; set; }
        public Attendance? TodayAttendance { get; set; }
        public LeaveBalance? LeaveBalance { get; set; }
        public List<Attendance> RecentHistory { get; set; } = new();
        public List<LeaveRequest> PendingLeaves { get; set; } = new();
    }

    public class PortalScheduleViewModel
    {
        public List<Schedule> ThisWeek { get; set; } = new();
        public List<Schedule> NextWeek { get; set; } = new();
        public DateTime WeekStart { get; set; }
    }

    public class PortalLeaveViewModel
    {
        public LeaveBalance? Balance { get; set; }
        public List<LeaveRequest> Requests { get; set; } = new();
        public LeaveRequest NewRequest { get; set; } = new();
    }
}
