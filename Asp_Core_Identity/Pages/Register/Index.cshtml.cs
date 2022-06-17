using System.Threading.Tasks;

using Asp_Core_Identity.Models.Dto;
using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Core_Identity.Pages.Register
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public IndexModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public RegisterDto register { get; set; } = new RegisterDto { };
        public void OnGet()
        {
        }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            User user = new User()
            {
                Email = register.Email,
                UserName = register.Email,
                Fullname = register.Fullname
            };
            var result =await _userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
                return RedirectToPage("index");

            foreach (var item in result.Errors)
                ModelState.AddModelError(item.Code, item.Description);
            return Page();
        }
    }
}
