using Distrib.Core.Application.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Distrib.Core.Api.Security.Builders
{
    public class SecurityBuilder : ConfigurationBuilderBase
    {
        public SecurityBuilder(IServiceCollection services, IConfiguration configuration)
            : base(services, configuration)
        {
        }
    }
}
