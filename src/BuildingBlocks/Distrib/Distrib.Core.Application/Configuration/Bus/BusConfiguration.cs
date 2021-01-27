using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Distrib.Core.Application.Configuration.Bus
{
    public static class BusConfiguration
    {
        public static BusBuilder AddMessageBus(this IServiceCollection services, IConfiguration configuration) =>
            new BusBuilder(services, configuration);
    }
}
