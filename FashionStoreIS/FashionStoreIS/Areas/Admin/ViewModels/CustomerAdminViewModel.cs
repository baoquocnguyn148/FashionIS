using FashionStoreIS.Models;

namespace FashionStoreIS.Areas.Admin.ViewModels
{
    public class CustomerAdminViewModel
    {
        public ApplicationUser User { get; set; } = null!;
        public int OrderCount { get; set; }
        public decimal TotalSpent { get; set; }
        public DateTime? LastOrderDate { get; set; }
    }
}
