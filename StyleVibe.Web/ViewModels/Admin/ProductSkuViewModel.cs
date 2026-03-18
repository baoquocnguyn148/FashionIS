using System.ComponentModel.DataAnnotations;

namespace StyleVibe.Web.ViewModels.Admin;

public class ProductSkuViewModel
{
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [Required]
    [MaxLength(30)]
    public string SkuCode { get; set; } = "";

    [Required]
    [MaxLength(10)]
    public string Size { get; set; } = "";

    [Required]
    [MaxLength(50)]
    public string Color { get; set; } = "";

    [Range(0, double.MaxValue)]
    public decimal CostPrice { get; set; }

    [Range(0, double.MaxValue)]
    public decimal SellingPrice { get; set; }

    public bool IsActive { get; set; } = true;
}

