using FashionStoreIS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FashionStoreIS.Areas.Identity.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            
            // XÓA COOKIE GIỎ HÀNG KHI ĐĂNG XUẤT ĐỂ NGĂN RÒ RỈ DATA (CART BLEEDING)
            if (Request.Cookies.ContainsKey("BNStore_Cart"))
            {
                Response.Cookies.Delete("BNStore_Cart");
            }

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
