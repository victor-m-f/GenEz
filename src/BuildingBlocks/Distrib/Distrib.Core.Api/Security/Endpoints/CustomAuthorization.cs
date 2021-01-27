using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Distrib.Core.Api.Security.Endpoints
{
    public class CustomAuthorization
    {
        public static bool ValidateUserClaims(HttpContext context, string claimName, string claimValue) =>
            context.User.Identity.IsAuthenticated &&
                   context.User.Identities.Any(x => x.Claims.Any(y => y.Value == claimValue && y.Properties.Any(z => z.Value == claimName)));
    }
}
