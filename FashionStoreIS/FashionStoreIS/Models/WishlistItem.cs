using System.ComponentModel.DataAnnotations.Schema;

namespace FashionStoreIS.Models
{
    /// <summary>
    /// Lưu sản phẩm yêu thích của khách hàng (Wishlist).
    /// Khoá duy nhất: (UserId, ProductId) — mỗi user chỉ lưu 1 lần mỗi sản phẩm.
    /// </summary>
    public class WishlistItem : BaseEntity
    {
        /// <summary>FK → ASPNETUSERS.ID</summary>
        public string UserId { get; set; } = null!;

        /// <summary>FK → PRODUCTS.ID</summary>
        public int ProductId { get; set; }

        // ─── Navigation Properties ──────────────────────────────────────────
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
