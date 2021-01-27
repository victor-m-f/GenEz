using Distrib.Core.Api.Configuration.General;
using Distrib.Helper.Helpers;
using GenEz.Character.Application.Configuration;
using GenEz.Character.Data.Configuration;
using GenEz.Character.Domain.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace GenEz.Web.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            SystemHelper.Initialize(environment.EnvironmentName);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization();
            services.AddApiConfiguration("GenEz", "Api para geração randômica de elementos de histórias", 1, 0, typeof(Startup));
            services.ConfigureCharacterApplication();
            services.ConfigureCharacterData(_configuration);
            services.ConfigureCharacterDomain();
        }

        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseApiConfiguration(provider, true);
            var hostUrl = _configuration[WebHostDefaults.ServerUrlsKey];
            Log.Information($"WebHost running on {hostUrl}.");
        }
    }
}
