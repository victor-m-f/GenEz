using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Distrib.Core.Application.Configuration.Bus
{
    public class BusBuilder
    {
        public virtual IServiceCollection Services { get; }
        public virtual IConfiguration Configuration { get; }

        public BusBuilder(IServiceCollection services, IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;
        }
    }
}
