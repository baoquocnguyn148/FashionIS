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

        public decimal BaseSalaryPerHour { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BankAccountName { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public string? UserId { get; set; }

        public int StoreId { get; set; }
        public virtual Store Store { get; set; } = null!;
    }
}
