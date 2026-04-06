using System;

namespace FashionStoreIS.Models
{
    public class KpiReview : BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = null!;
        public string ReviewerId { get; set; } = null!;       // FK -> AspNetUsers.Id
        public virtual ApplicationUser Reviewer { get; set; } = null!;
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal SalesScore { get; set; }               // 0-100
        public decimal AttitudeScore { get; set; }            // 0-100
        public decimal TeamworkScore { get; set; }            // 0-100
        public decimal TotalScore { get; set; }               // Weighted average
        public KpiRank Rank { get; set; }
        public string? Notes { get; set; }
    }
}
