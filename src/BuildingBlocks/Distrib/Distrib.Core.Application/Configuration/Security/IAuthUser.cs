using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Distrib.Core.Application.Configuration.Security
{
    public interface IAuthUser
    {
        Guid GetId();
        string GetEmail();
        string GetUserToken();
        bool IsAuthenticated();
        bool HasRole(string role);
        IEnumerable<Claim> GetClaims();
        HttpContext GetHttpContext();
    }
}
