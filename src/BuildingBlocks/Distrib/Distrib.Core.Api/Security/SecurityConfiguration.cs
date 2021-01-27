using Distrib.Core.Api.Security.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Distrib.Core.Api.Configuration.Security
{
    public static class SecurityConfiguration
    {
        public static SecurityBuilder AddSecurityConfiguration(this IServiceCollection services, IConfiguration configuration) =>
            new SecurityBuilder(services, configuration);
    }
}
