using System;

namespace FashionStoreIS.Models
{
    public class LeaveRequest : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType Type { get; set; }
        public LeaveStatus Status { get; set; } = LeaveStatus.Pending;
        public string? Reason { get; set; }
        public string? AdminNote { get; set; }
        public string? ApprovedById { get; set; } // Reference to ApplicationUser
    }
}
