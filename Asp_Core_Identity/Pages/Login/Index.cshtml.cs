using System.Threading.Tasks;

using Asp_Core_Identity.Models.Dto;
using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;

namespace Asp_Core_Identity.Pages.Login
{
    public class IndexModel : PageModel
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IndexModel(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public LoginDto Login { get; set; } = new LoginDto { };
        public void OnGet(string returnUrl="/")
        {
            Login.ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = _userManager.FindByNameAsync(Login.UserName).Result;

           await _signInManager.SignOutAsync();

           var result= _signInManager.PasswordSignInAsync(user, Login.Password, true,true).Result;
            if (result.Succeeded)
                return Redirect(Login.ReturnUrl);
            if (result.RequiresTwoFactor)
            {
                //
            }
            if (result.IsLockedOut)
            {
                //
            }
  
                ModelState.AddModelError("", "");
            return Page();
        }
    }
}
