using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using System;
using System.Net.Http;

namespace Distrib.Core.Api.Resilience
{
    /// <summary>
    /// Resiliency helper methods using polly.
    /// </summary>
    public static class PollyExtensions
    {
        /// <summary>
        /// Creates a retry policy for HttpResponseMessages.
        /// </summary>
        /// <returns>A configured retry policy.</returns>
        public static AsyncRetryPolicy<HttpResponseMessage> WaitAndRetryAsync()
        {
            var retry = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(5),
                    TimeSpan.FromSeconds(10),
                });

            return retry;
        }
    }
}
