using Microsoft.AspNetCore.Identity;

namespace Asp_Core_Identity.Models.Entities
{
    public class User:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
