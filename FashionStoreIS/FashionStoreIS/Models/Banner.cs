using System.ComponentModel.DataAnnotations;

namespace FashionStoreIS.Models
{
    public class Banner : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = "";

        public string? SubTitle { get; set; }

        public string? ImageUrl { get; set; }

        [MaxLength(200)]
        public string? LinkUrl { get; set; }

        [MaxLength(50)]
        public string? Position { get; set; } = "Hero"; // "Hero", "Category1", "Category2", "Category3"

        public bool IsActive { get; set; } = true;

        public int DisplayOrder { get; set; } = 0;
    }
}
