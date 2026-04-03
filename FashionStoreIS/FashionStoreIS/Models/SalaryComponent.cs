namespace FashionStoreIS.Models
{
    public class SalaryComponent : BaseEntity
    {
        public string Name { get; set; } = null!;
        public SalaryComponentType Type { get; set; }
        public decimal DefaultAmount { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
