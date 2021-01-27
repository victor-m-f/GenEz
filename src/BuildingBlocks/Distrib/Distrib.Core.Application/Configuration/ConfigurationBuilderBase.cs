using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Distrib.Core.Application.Configuration
{
    public abstract class ConfigurationBuilderBase
    {
        #region Properties

        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }

        #endregion

        #region Constructors

        public ConfigurationBuilderBase(
            IServiceCollection services,
            IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;
        }

        #endregion
    }
}
