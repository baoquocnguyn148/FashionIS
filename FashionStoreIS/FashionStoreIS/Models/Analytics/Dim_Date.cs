using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models.Analytics
{
    [Table("Dim_Date")]
    public class Dim_Date
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DateKey { get; set; } // Format: yyyyMMdd (e.g., 20240322)
        
        public DateTime Date { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public bool IsWeekend { get; set; }
    }
}
