using Distrib.Core.Api.Controllers;
using Distrib.Core.Application.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Distrib.Core.Api.Middlewares
{
    public class ScopedLoggingMiddleware
    {
        private const string RequestIdName = "RequestId";
        private readonly RequestDelegate _next;
        private readonly ILogger<ScopedLoggingMiddleware> _logger;

        public ScopedLoggingMiddleware(
            RequestDelegate next,
            ILogger<ScopedLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestId = GetOrAddCorrelationHeader(context);
            using (LogHelper.OpenScope(requestId))
            {
                ApiRequest.Register(_logger, context.Request);
                await _next.Invoke(context);
            }
        }

        private string GetOrAddCorrelationHeader(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Request.Headers[RequestIdName]))
            {
                context.Request.Headers[RequestIdName] = Guid.NewGuid().ToString();
            }

            return context.Request.Headers[RequestIdName];
        }
    }
}
