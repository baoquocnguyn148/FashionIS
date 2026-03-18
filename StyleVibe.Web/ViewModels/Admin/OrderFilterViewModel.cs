using StyleVibe.Domain.Enums;

namespace StyleVibe.Web.ViewModels.Admin;

public class OrderFilterViewModel
{
    public OrderStatus? Status { get; set; }
    public int? StoreId { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public string? Search { get; set; }
    public int Page { get; set; } = 1;
}

