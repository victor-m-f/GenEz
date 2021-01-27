using Distrib.Core.Api.Configuration.Documentation;
using Distrib.Core.Api.Controllers.Responses;
using Distrib.Core.Api.Middlewares;
using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Configuration.General;
using Distrib.Helper.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace Distrib.Core.Api.Configuration.General
{
    /// <summary>
    /// Exposes methods for configuring Api projects.
    /// </summary>
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services, string apiName, string apiDescription, int majorVersion, int minorVersion, Type startupType)
        {
            // services.AddLocalizer();
            _ = services.AddCors(options =>
            {
                options.AddPolicy(
                    "Total",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            _ = services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var errors = context.ModelState.Values.SelectMany(v => v.Errors);
                        var body = context.ActionDescriptor.Parameters.FirstOrDefault(p =>
                            p.BindingInfo.BindingSource.DisplayName == "Body");

                        var sp = services.BuildServiceProvider();
                        var logger = sp.GetService<ILogger<object>>();

                        var apiResponse = new ApiResponse(
                            errors.Select(e =>
                                new ErrorNotification(
                                    HttpStatusCode.BadRequest,
                                    body?.ParameterType.Name,
                                    e.ErrorMessage)).ToList());

                        return apiResponse.Send(logger);
                    };
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.IgnoreNullValues = false;
                });

            _ = services.AddHttpContextAccessor();

            services.AddVersioning(majorVersion, minorVersion);

            _ = services.AddDocumentationConfiguration(apiName, apiDescription);

            services.AddMediatorConfiguration(startupType);
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

        public static void UseApiConfiguration(this IApplicationBuilder app, IApiVersionDescriptionProvider versionProvider, bool httpsRedirect = false)
        {
            app.UseForwardedHeaders();
            app.UseDocumentationConfiguration(versionProvider);

            if (SystemHelper.IsDevelopment)
            {
                app.UseDeveloperExceptionPage();
            }

            if (httpsRedirect)
            {
                app.UseHttpsRedirection();
            }

            // app.UseLocalizer();
            app.UseRouting();
            app.UseMiddleware<ScopedLoggingMiddleware>();
            app.UseMiddleware<ErrorMiddleware>();
            app.UseCors("Total");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
                endpoints.MapControllerRoute("default", "{culture:culture}/{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static void AddVersioning(this IServiceCollection services, int majorVersion, int minorVersion)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(majorVersion, minorVersion);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        }
    }
}
