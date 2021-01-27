using Distrib.Core.Api.Controllers.Responses;
using Distrib.Core.Api.Security.Builders;
using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Configuration.AppSettings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetDevPack.Security.JwtExtensions;
using System.Net;

namespace Distrib.Core.Api.Security.Jwt
{
    public static class JwtConfiguration
    {
        public static JwtAuthenticationBuilder AddJwtAuthentication(this SecurityBuilder securityBuilder, IServiceCollection services)
        {
            var jwtSettings = securityBuilder.Services.AddAppSettings<JwtAppSettings>(securityBuilder.Configuration, JwtAppSettings.SectionName);

            securityBuilder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                bearerOptions.RequireHttpsMetadata = false;
                bearerOptions.SaveToken = true;
                bearerOptions.SetJwksOptions(new JwkOptions(jwtSettings.JwksUrl));
                bearerOptions.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        if (context.Error == null)
                        {
                            return;
                        }

                        var sp = services.BuildServiceProvider();
                        var logger = sp.GetService<ILogger<object>>();

                        var value = string.IsNullOrEmpty(context.ErrorDescription) ? context.AuthenticateFailure.Message : context.ErrorDescription;

                        var apiResponse = new ApiResponse(new ErrorNotification(HttpStatusCode.Unauthorized, context.Error, value, true));

                        await apiResponse.SendAsync(logger, context.HttpContext);

                        context.HandleResponse();
                    },
                };
            });

            return new JwtAuthenticationBuilder(securityBuilder.Services, securityBuilder.Configuration);
        }
    }
}
