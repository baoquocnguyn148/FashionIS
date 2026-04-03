using System.ComponentModel.DataAnnotations;

namespace FashionStoreIS.Models
{
    public class UserAddress : BaseEntity
    {
        [Required]
        [MaxLength(450)]
        public string UserId { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string AddressLine { get; set; } = null!;

        public bool IsDefault { get; set; } = false;
    }
}
