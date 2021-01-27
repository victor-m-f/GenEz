using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Distrib.Core.Api.Security.Endpoints
{
    public class AuthorizeRoleAttribute : TypeFilterAttribute
    {
        public AuthorizeRoleAttribute(string roleValue)
            : base(typeof(RequirementClaimFilter))
        {
            Arguments = new object[] { new Claim(RegisteredClaimNames.Role, roleValue) };
        }
    }
}
