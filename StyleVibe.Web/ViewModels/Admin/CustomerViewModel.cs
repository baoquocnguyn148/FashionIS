using System.ComponentModel.DataAnnotations;
using StyleVibe.Domain.Enums;

namespace StyleVibe.Web.ViewModels.Admin;

public class CustomerViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập họ tên")]
    [MaxLength(100)]
    public string FullName { get; set; } = "";

    [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
    [MaxLength(20)]
    [Phone]
    public string Phone { get; set; } = "";

    [EmailAddress]
    [MaxLength(100)]
    public string? Email { get; set; }

    [MaxLength(200)]
    public string? Address { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public CustomerTier Tier { get; set; } = CustomerTier.Bronze;

    public int LoyaltyPoints { get; set; }
}
