using Destructurama;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Context;
using System;
using System.IO;

namespace Distrib.Core.Application.Logging
{
    public static class LogHelper
    {
        private const string ScopeName = "Scope";

        public static ILogger GetConfiguredLogger()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false, true)
                .Build();

            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Destructure.UsingAttributes()
                .CreateLogger();
        }

        public static IDisposable OpenScope(string value) => LogContext.PushProperty(ScopeName, value);
    }
}
