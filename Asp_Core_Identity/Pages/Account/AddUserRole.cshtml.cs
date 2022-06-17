using System.Collections.Generic;
using System.Linq;

using Asp_Core_Identity.Models.Dto;
using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Core_Identity.Pages.Account
{
    public class AddUserRoleModel : PageModel
    {
        private readonly RoleManager<Role> _roleManager;

        public AddUserRoleModel(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        [BindProperty]
        public AddUserRoleDto adduser { set; get; } =new AddUserRoleDto();

        public void OnGet(int id)
        {
            var roles = new List<SelectListItem>(_roleManager.Roles.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value=x.Name

            }).ToList());

            adduser.Roles = roles;
            adduser.Id  = id;

        }
    }
}
