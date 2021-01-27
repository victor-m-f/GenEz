using Distrib.Core.Application.Communication.Errors;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Distrib.Core.Api.Controllers.Responses
{
    public class ApiResponseWithResult<T> : ApiResponse
    {
        #region Properties

        [JsonProperty("result")]
        public T Result { get; set; }

        #endregion

        #region Constructors

        public ApiResponseWithResult()
        {
        }

        public ApiResponseWithResult(T result)
            : this(result, Enumerable.Empty<ErrorNotification>())
        {
        }

        public ApiResponseWithResult(T result, IEnumerable<ErrorNotification> errors)
            : base(errors)
        {
            Result = result;
        }

        public ApiResponseWithResult(T result, ErrorNotification error)
            : this(result, new List<ErrorNotification> { error })
        {
        }

        #endregion
    }
}
