namespace FashionStoreIS.Models
{
    public class PayrollItem : BaseEntity
    {
        public int PayrollId { get; set; }
        public virtual Payroll Payroll { get; set; } = null!;

        public int? SalaryComponentId { get; set; }
        public virtual SalaryComponent? SalaryComponent { get; set; }

        public decimal Amount { get; set; }
        public string? Note { get; set; }
    }
}
