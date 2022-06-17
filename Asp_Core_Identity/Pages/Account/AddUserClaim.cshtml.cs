using System.Security.Claims;

using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Core_Identity.Pages.Account
{
    public class AddUserClaimModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public AddUserClaimModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public string Id { get; set; }


        public void OnGet(string id)
        {
            Id = id;
        }
        public IActionResult OnPost()
        {
            var user = _userManager.FindByIdAsync(Id).Result;

            Claim newClaim = new Claim("Admin", "Admin", ClaimValueTypes.String);
            var result = _userManager.AddClaimAsync(user, newClaim).Result;
            if (result.Succeeded)
            {
                return Redirect("/");
            }
            return Page();
        }
    }
}
