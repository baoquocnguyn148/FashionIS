using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FashionStoreIS.Models;
using System.Threading.Tasks;

namespace FashionStoreIS.Areas.Identity.Pages.Account.Manage
{
    public class MembershipModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MembershipModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUser AppUser { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            AppUser = await _userManager.GetUserAsync(User);
            if (AppUser == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            return Page();
        }
    }
}
