using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Distrib.Core.Application.Configuration.Security
{
    internal class AuthUser : IAuthUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthUser(IHttpContextAccessor httpContextAcessor)
        {
            _httpContextAccessor = httpContextAcessor;
        }

        public Guid GetId() => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        public string GetEmail() => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;

        public string GetUserToken()
        {
            return IsAuthenticated() ? GetUserToken(_httpContextAccessor.HttpContext.User) : string.Empty;
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool HasRole(string role)
        {
            return _httpContextAccessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetClaims()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }

        public HttpContext GetHttpContext()
        {
            return _httpContextAccessor.HttpContext;
        }

        private string GetUserToken(ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst("JWT");
            return claim?.Value;
        }
    }
}
