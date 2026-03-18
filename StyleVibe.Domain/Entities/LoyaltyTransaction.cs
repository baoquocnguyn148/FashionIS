using StyleVibe.Domain.Common;

namespace StyleVibe.Domain.Entities;

public class LoyaltyTransaction : BaseEntity
{
    public int Points { get; set; }
    public string Description { get; set; } = null!;

    public int? OrderId { get; set; }
    public Order? Order { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
}

