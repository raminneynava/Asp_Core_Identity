using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Core_Identity
{ 
    public class MvcNamesModel
    {
        public MvcNamesModel(string areaName, string controllerName, string actionName, string claimToAuthorize)
        {
            AreaName = areaName;
            ControllerName = controllerName;
            ActionName = actionName;
            ClaimToAuthorize = claimToAuthorize;
            IsClaimBasedAuthorizationRequired = !string.IsNullOrWhiteSpace(claimToAuthorize);
        }

        public MvcNamesModel(string areaName, string controllerName, string actionName)
        {
            AreaName = areaName;
            ControllerName = controllerName;
            ActionName = actionName;
            ClaimToAuthorize = null;
            IsClaimBasedAuthorizationRequired = false;
        }
        
        public string AreaName { get; }
        public string ControllerName { get; }
        public string ActionName { get; }
        public string ClaimToAuthorize { get; }
        public bool IsClaimBasedAuthorizationRequired { get; }
    }
}
