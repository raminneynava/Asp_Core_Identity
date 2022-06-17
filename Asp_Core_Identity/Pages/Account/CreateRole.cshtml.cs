using System.Collections.Generic;

using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Core_Identity.Pages.Account
{
    public class CreateRoleModel : PageModel
    {
        private readonly RoleManager<Role> _roleManager;

        public CreateRoleModel(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        public Role Role { get; set; } = new Role();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Role role = new Role();
            role.Name = Role.Name;
            role.Description = Role.Description;
            var res = _roleManager.CreateAsync(role).Result;
            if (res.Succeeded)
                return RedirectToPage("RoleList");

            return Page();
        }
    }
}
