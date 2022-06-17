using Microsoft.AspNetCore.Identity;

namespace Asp_Core_Identity.Models.Entities
{
    public class Role:IdentityRole
    {
        public string Description { get; set; }
    }
}
