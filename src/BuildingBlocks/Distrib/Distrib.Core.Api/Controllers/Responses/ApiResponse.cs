using Distrib.Core.Application.Communication.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Distrib.Core.Api.Controllers.Responses
{
    public class ApiResponse
    {
        private const string LogMessageTemplate = "Response {@apiResponse} returned.";

        #region Properties

        [JsonProperty("succeeded")]
        public bool Succeeded { get; set; }
        [JsonProperty("errors")]
        public IEnumerable<ErrorNotification> Errors { get; set; }
        [JsonProperty("httpStatusCode")]
        public int HttpStatusCode { get; private set; }

        #endregion

        #region Constructors

        public ApiResponse()
            : this(Enumerable.Empty<ErrorNotification>())
        {
        }

        public ApiResponse(IEnumerable<ErrorNotification> errors)
        {
            Succeeded = !errors?.Any(e => e.IsFatal) != false;
            Errors = errors;
            DefineHttpStatusCode();
        }

        public ApiResponse(ErrorNotification error)
            : this(new List<ErrorNotification> { error })
        {
        }

        #endregion

        public override string ToString() => JsonConvert.SerializeObject(this);

        public ObjectResult Send(ILogger logger)
        {
            Log(logger);

            return new ObjectResult(this)
            {
                StatusCode = HttpStatusCode,
            };
        }

        public Task SendAsync(ILogger logger, HttpContext context)
        {
            Log(logger);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = Errors.First().HttpStatusCode;
            return context.Response.WriteAsync(ToString());
        }

        private void DefineHttpStatusCode()
        {
            HttpStatusCode = Succeeded ? (int)System.Net.HttpStatusCode.OK : Errors.First().HttpStatusCode;
        }

        private void Log(ILogger logger)
        {
            if (HttpStatusCode == (int)System.Net.HttpStatusCode.OK)
            {
                logger.LogInformation(LogMessageTemplate, this);
            }
            else if (HttpStatusCode == (int)System.Net.HttpStatusCode.InternalServerError)
            {
                logger.LogError(LogMessageTemplate, this);
            }
            else
            {
                logger.LogWarning(LogMessageTemplate, this);
            }
        }
    }
}
