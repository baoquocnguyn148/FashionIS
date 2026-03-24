using StyleVibe.Domain.Common;

namespace StyleVibe.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public int Stock { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;

    public ICollection<ProductSku> Skus { get; set; } = new List<ProductSku>();
}

