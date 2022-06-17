using System.Collections.Generic;
using System.Linq;

using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Core_Identity.Pages.Account
{
    public class RoleListModel : PageModel
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleListModel(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        [BindProperty]
        public List<Role> RoleList { get; set; } = new List<Role>();
        public void OnGet()
        {
            RoleList = _roleManager.Roles.ToList();
        }
    }
}
