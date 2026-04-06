using System;

namespace FashionStoreIS.Models
{
    public class Shift : BaseEntity
    {
        public string Name { get; set; } = null!;        // "Ca Sáng", "Ca Chiều", "Ca Tối"
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int StoreId { get; set; }
        public virtual Store Store { get; set; } = null!;
        public bool IsActive { get; set; } = true;
    }
}
