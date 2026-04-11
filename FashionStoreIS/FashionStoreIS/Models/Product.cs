using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; } = true;

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; } = null!;

        public virtual ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public virtual ICollection<ProductSku> Skus { get; set; } = new List<ProductSku>();
        public virtual ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();
    }
}
