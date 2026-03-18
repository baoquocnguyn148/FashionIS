using StyleVibe.Domain.Common;
using StyleVibe.Domain.Enums;

namespace StyleVibe.Domain.Entities;

public class Customer : BaseEntity
{
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Email { get; set; }
    public string? Address { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public CustomerTier Tier { get; set; } = CustomerTier.Bronze;
    public int LoyaltyPoints { get; set; }
    public string? UserId { get; set; } // FK to AspNetUsers when Identity is added
    public DateTime JoinDate { get; set; } = DateTime.UtcNow;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<LoyaltyTransaction> LoyaltyTransactions { get; set; } = new List<LoyaltyTransaction>();
}

