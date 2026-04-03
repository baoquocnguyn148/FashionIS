using System.ComponentModel.DataAnnotations;

namespace FashionStoreIS.Models
{
    public class Notification : BaseEntity
    {
        [Required]
        [MaxLength(450)]
        public string UserId { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; } = null!;

        public bool IsRead { get; set; } = false;
        
        [MaxLength(255)]
        public string? ActionUrl { get; set; }
    }
}
