using System.Collections.Generic;

namespace FashionStoreIS.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
