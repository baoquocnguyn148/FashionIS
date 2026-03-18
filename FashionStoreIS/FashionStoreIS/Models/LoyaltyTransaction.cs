namespace FashionStoreIS.Models
{
    public class LoyaltyTransaction : BaseEntity
    {
        public int Points { get; set; }
        public string Description { get; set; } = null!;

        public int? OrderId { get; set; }
        public virtual Order? Order { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
    }
}
