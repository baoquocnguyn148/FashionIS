namespace FashionStoreIS.Areas.Admin.ViewModels.Crm
{
    public class TimelineEventViewModel
    {
        public DateTime EventDate    { get; set; }
        public string EventType      { get; set; } = ""; // Order | Return | Notification | Points
        public string Icon           { get; set; } = "fa-circle";
        public string Color          { get; set; } = "#6366f1";
        public string Title          { get; set; } = "";
        public string Description    { get; set; } = "";
        public string? LinkUrl       { get; set; }
        public string? Badge         { get; set; } // e.g. "Đã giao", "Hoàn tiền"
        public string? BadgeColor    { get; set; }
    }
}
