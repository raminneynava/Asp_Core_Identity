using System.ComponentModel.DataAnnotations;

namespace Asp_Core_Identity.Models.Dto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
