using System;

namespace FashionStoreIS.Models
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Position { get; set; } = null!;
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string? UserId { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; } = null!;
    }
}
