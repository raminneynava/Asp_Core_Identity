
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Asp_Core_Identity.Pages
{
    [Authorize(Policy = "AdminInsert")]
    public class raminModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
