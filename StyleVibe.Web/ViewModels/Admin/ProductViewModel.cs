using System.ComponentModel.DataAnnotations;

namespace StyleVibe.Web.ViewModels.Admin;

public class ProductViewModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = "";

    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }

    [Range(1, int.MaxValue)]
    public int SupplierId { get; set; }

    public bool IsActive { get; set; } = true;
}

