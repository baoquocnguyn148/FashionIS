using FashionStoreIS.Services;

namespace FashionStoreIS.Areas.Admin.ViewModels.Crm
{
    public class SegmentsViewModel
    {
        public Dictionary<string, List<CustomerRfmSummary>> Segments { get; set; } = new();
        public int TotalCustomers { get; set; }

        // Summary counts
        public int Champions          => Segments.TryGetValue("Champions", out var v) ? v.Count : 0;
        public int Loyal              => Segments.TryGetValue("Loyal", out var v) ? v.Count : 0;
        public int PotentialLoyalists => Segments.TryGetValue("PotentialLoyalists", out var v) ? v.Count : 0;
        public int New                => Segments.TryGetValue("New", out var v) ? v.Count : 0;
        public int AtRisk             => Segments.TryGetValue("AtRisk", out var v) ? v.Count : 0;
        public int Lost               => Segments.TryGetValue("Lost", out var v) ? v.Count : 0;
        public int Others             => Segments.TryGetValue("Others", out var v) ? v.Count : 0;
    }
}
