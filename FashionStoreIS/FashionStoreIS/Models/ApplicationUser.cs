using Microsoft.AspNetCore.Identity;
using FashionStoreIS.Models.Executive;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        
        public string? Gender { get; set; }
        
        public string? AvatarUrl { get; set; }
        
        public int MembershipPoints { get; set; } = 0;
        public DateTime JoinDate { get; set; } = DateTime.Now;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<UserAddress> Addresses { get; set; } = new List<UserAddress>();
        public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
        public virtual ICollection<ExecutiveAlert> ExecutiveAlerts { get; set; } = new List<ExecutiveAlert>();
        public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    }
}
