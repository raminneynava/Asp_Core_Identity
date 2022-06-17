using System.Collections.Generic;
using System.Linq;

using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Core_Identity.Pages.Account
{
    public class UserListModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public UserListModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public List<User> UserList { get; set; }=new List<User>();
        public void OnGet()
        {
            UserList = _userManager.Users.ToList();
        }
    }
}
