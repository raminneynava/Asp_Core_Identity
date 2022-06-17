using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Asp_Core_Identity.Models.Dto
{
    public class AddUserRoleDto
    {
        public int Id { get; set; }
        public string  Role { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}
