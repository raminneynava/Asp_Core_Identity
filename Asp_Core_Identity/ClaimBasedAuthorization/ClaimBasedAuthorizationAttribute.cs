using Microsoft.AspNetCore.Authorization;
using System;

namespace Asp_Core_Identity.ClaimBasedAuthorization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ClaimBasedAuthorizationAttribute : AuthorizeAttribute
    {
        public ClaimBasedAuthorizationAttribute(string claimToAuthorize) : base("a")
        {
            ClaimToAuthorize = claimToAuthorize;
        }

        public string ClaimToAuthorize { get; }
    }
}
