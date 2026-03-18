using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models
{
    public class ProductImage : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; } = null!;

        public string ImageUrl { get; set; } = "";

        public int DisplayOrder { get; set; } = 0;
    }
}
