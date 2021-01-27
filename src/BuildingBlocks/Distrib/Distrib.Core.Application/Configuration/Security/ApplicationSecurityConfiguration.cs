using Microsoft.Extensions.DependencyInjection;

namespace Distrib.Core.Application.Configuration.Security
{
    public static class ApplicationSecurityConfiguration
    {
        public static void InjectAuthUser(this IServiceCollection services)
        {
            _ = services.AddScoped<IAuthUser, AuthUser>();
        }
    }
}
