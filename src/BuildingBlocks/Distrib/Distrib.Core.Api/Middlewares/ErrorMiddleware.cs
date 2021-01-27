using Distrib.Core.Api.Controllers.Responses;
using Distrib.Core.Application.Communication.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Distrib.Core.Api.Middlewares
{
    /// <summary>
    /// Middleware that handles application errors globally.
    /// </summary>
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorMiddleware> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorMiddleware"/> class.
        /// </summary>
        /// <param name="next">A function that will process the next HTTP request.</param>
        /// <param name="logger">Includes methods for logging records.</param>
        public ErrorMiddleware(RequestDelegate next, ILogger<ErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Calls the next delegate/middleware in the pipeline.
        /// </summary>
        /// <param name="httpContext">The HTTP request to be processed.</param>
        /// <returns>A task that represents the completion of request processing.</returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var error = new ErrorNotification(HttpStatusCode.InternalServerError, exception.Message, exception.InnerException?.Message?? exception.StackTrace);

            var apiResponse = new ApiResponse(error);

            return apiResponse.SendAsync(_logger, context);
        }
    }
}
