using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using Asp_Core_Identity.Data;
using Asp_Core_Identity.Models;
using Asp_Core_Identity.Models.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Core_Identity.Pages.Account
{
    public class AddUserClaimModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly DataBaseContext _db;

        public AddUserClaimModel(UserManager<User> userManager, DataBaseContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public List<Perrmisions> Perrmisions { get; set; }=new List<Perrmisions>();

        public void OnGet(string id)
        {
            Id = id ;
            Perrmisions = _db.Perrmisions.ToList();
            var user = _userManager.FindByIdAsync(id).Result;
            var userclaim = _userManager.GetClaimsAsync(user).Result;
            foreach (var item in Perrmisions)
            {
                if (userclaim.Any(x => x.Type == item.Name))
                {
                    item.IsCkeck=true;
                }
            }
        }
        public IActionResult OnPost()
        {
            var user = _userManager.FindByIdAsync(Id).Result;
            foreach(var item in Perrmisions)
            {
                Claim newClaim = new Claim(item.Name, item.Name, ClaimValueTypes.String);
                if (item.IsCkeck)
                {
                    var result = _userManager.AddClaimAsync(user, newClaim).Result;

                }
                else
                {

                    var result = _userManager.RemoveClaimAsync(user, newClaim).Result;
                }

            }
         


            //if (result.Succeeded)
            //{
            //    return Redirect("/");
            //}
            return Page();
        }
    }
}
