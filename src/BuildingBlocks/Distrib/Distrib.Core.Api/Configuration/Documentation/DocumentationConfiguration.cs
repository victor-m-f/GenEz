using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Distrib.Core.Api.Configuration.Documentation
{
    internal static class DocumentationConfiguration
    {
        public static IServiceCollection AddDocumentationConfiguration(this IServiceCollection services, string apiName, string apiDescription)
        {
            var sp = services.BuildServiceProvider();
            var versionProvider = sp.GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(c =>
            {
                foreach (var description in versionProvider.ApiVersionDescriptions)
                {
                    c.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Title = $"{apiName} API {description.GroupName}",
                        Description = apiDescription,
                        Contact = new OpenApiContact { Name = "API Contact", Email = "contact@email.com" },
                        License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") },
                    });
                }

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    },
                });
            });

            return services;
        }

        public static IApplicationBuilder UseDocumentationConfiguration(this IApplicationBuilder app, IApiVersionDescriptionProvider versionProvider)
        {
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(AssemblyDirectory, "Configuration/Documentation/Ui")),
                RequestPath = "/Ui",
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                // options.DocumentTitle = "Default Api";
                c.InjectJavascript("../Ui/favIcon.js");
                c.InjectStylesheet("../Ui/darkmode.css");

                foreach (var description in versionProvider.ApiVersionDescriptions)
                {
                    c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                }
            });

            return app;
        }

        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
