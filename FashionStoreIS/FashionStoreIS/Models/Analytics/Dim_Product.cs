using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models.Analytics
{
    [Table("Dim_Product")]
    public class Dim_Product
    {
        [Key]
        public int ProductSurrogateKey { get; set; } // DWH Auto-increment key
        
        public int ProductId { get; set; } // Mapping back to OLTP Product
        public int? ProductSkuId { get; set; } // Mapping back to OLTP Sku (Variant)
        
        public string ProductName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        
        // Slowly Changing Dimension (SCD) Type 2 tracking
        public bool IsActive { get; set; } = true; 
        public DateTime ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
