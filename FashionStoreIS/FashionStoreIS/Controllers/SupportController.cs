using Microsoft.AspNetCore.Mvc;

namespace FashionStoreIS.Controllers
{
    public class SupportController : Controller
    {
        // ─── GET /Support/BuyingGuide ──────────────────────────────────
        public IActionResult BuyingGuide()
        {
            ViewData["Title"] = "Hướng dẫn mua hàng";
            return View();
        }

        // ─── GET /Support/ReturnPolicy ─────────────────────────────────
        public IActionResult ReturnPolicy()
        {
            ViewData["Title"] = "Chính sách đổi trả";
            return View();
        }

        // ─── GET /Support/SizeGuide ────────────────────────────────────
        public IActionResult SizeGuide()
        {
            ViewData["Title"] = "Bảng size";
            return View();
        }

        // ─── GET /Support/Contact ──────────────────────────────────────
        public IActionResult Contact()
        {
            ViewData["Title"] = "Liên hệ";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(string name, string email, string message)
        {
            // Xử lý gửi tin nhắn (ở đây giả lập thành công)
            TempData["Success"] = "Cảm ơn bạn đã liên hệ. Chúng tôi sẽ phản hồi sớm nhất!";
            return RedirectToAction(nameof(Contact));
        }

        // ─── GET /Support/Stores ───────────────────────────────────────
        public IActionResult Stores()
        {
            ViewData["Title"] = "Hệ thống cửa hàng";
            return View();
        }
    }
}
