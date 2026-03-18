using StyleVibe.Domain.Common;

namespace StyleVibe.Domain.Entities;

public class Employee : BaseEntity
{
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Position { get; set; } = null!;
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; } = true;
    public string? UserId { get; set; } // FK to AspNetUsers when Identity is added

    public int StoreId { get; set; }
    public Store Store { get; set; } = null!;
}

