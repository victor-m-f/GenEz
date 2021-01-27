using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Distrib.Core.Application.Configuration.AppSettings
{
    public static class AppSettingsConfiguration
    {
        public static TAppSettings AddAppSettings<TAppSettings>(this IServiceCollection services, IConfiguration configuration, string sectionName)
            where TAppSettings : AppSettingsBase
        {
            var appSettingsSection = configuration.GetSection(sectionName);
            services.Configure<TAppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<TAppSettings>();

            if (appSettings?.IsValid != true)
            {
                throw new AppSettingsException(sectionName);
            }

            return appSettings;
        }
    }
}
