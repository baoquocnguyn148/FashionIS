using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models.Analytics
{
    [Table("Fact_Sales")]
    public class Fact_Sales
    {
        [Key]
        public int FactSalesId { get; set; }
        
        // --- Foreign Keys to Dimensions ---
        public int DateKey { get; set; }
        [ForeignKey("DateKey")]
        public Dim_Date DimDate { get; set; }
        
        public int ProductSurrogateKey { get; set; }
        [ForeignKey("ProductSurrogateKey")]
        public Dim_Product DimProduct { get; set; }
        
        public int CustomerSurrogateKey { get; set; }
        [ForeignKey("CustomerSurrogateKey")]
        public Dim_Customer DimCustomer { get; set; }
        
        // --- Degenerate Dimensions (Order level info) ---
        public int OrderId { get; set; } 
        public string OrderCode { get; set; } = string.Empty;
        
        // --- Metrics (Facts) ---
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalesAmount { get; set; } // Quantity * UnitPrice
        public decimal DiscountAmount { get; set; } // Appropriated discount for this line item
        public decimal COGS { get; set; } // Cost of Goods Sold: Quantity * Purchase UnitCost
        public decimal GrossProfit { get; set; } // SalesAmount - DiscountAmount - COGS
    }
}
