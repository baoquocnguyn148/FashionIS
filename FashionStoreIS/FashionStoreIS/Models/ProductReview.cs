using System;
using System.ComponentModel.DataAnnotations;

namespace FashionStoreIS.Models
{
    public class ProductReview : BaseEntity
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public virtual ApplicationUser User { get; set; } = null!;

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string? Comment { get; set; }

        public bool IsApproved { get; set; } = true;
    }
}
