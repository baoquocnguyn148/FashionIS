using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models.Analytics
{
    [Table("Dim_Customer")]
    public class Dim_Customer
    {
        [Key]
        public int CustomerSurrogateKey { get; set; } // DWH Auto-increment key
        
        [MaxLength(450)]
        public string CustomerId { get; set; } = string.Empty; // AspNetUserId mapping
        
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string RegionOrCity { get; set; } = string.Empty; // Derived from OLTP Address
    }
}
