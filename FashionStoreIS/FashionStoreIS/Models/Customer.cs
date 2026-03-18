using System;
using System.Collections.Generic;

namespace FashionStoreIS.Models
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int Tier { get; set; }
        public int LoyaltyPoints { get; set; }
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.Now;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
