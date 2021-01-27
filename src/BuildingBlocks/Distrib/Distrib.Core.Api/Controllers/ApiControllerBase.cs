using Distrib.Core.Api.Controllers.Responses;
using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Communication.Mediator;
using Distrib.Core.Domain.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Distrib.Core.Api.Controllers
{
    [ApiController]
    [ApiRoute]
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ErrorHandler _errorHandler;

        #region Properties

        protected IMediatorHandler Mediator { get; }

        #endregion

        #region Constructors

        protected ApiControllerBase(
            ILogger logger,
            INotificationHandler<ErrorNotification> errorHandler,
            IMediatorHandler mediator)
        {
            _logger = logger;
            _errorHandler = (ErrorHandler)errorHandler;
            Mediator = mediator;
        }

        #endregion

        protected ActionResult<ApiResponse> Respond()
        {
            var response = new ApiResponse(_errorHandler.GetNotifications());
            return response.Send(_logger);
        }

        protected ActionResult<ApiResponseWithResult<T>> Respond<T>(T result)
            where T : class
        {
            var response = new ApiResponseWithResult<T>(result, _errorHandler.GetNotifications());
            return response.Send(_logger);
        }

        protected ActionResult<PaginatedApiResponse<T>> Respond<T>(PaginatedListBase<T> result)
            where T : class
        {
            var response = new PaginatedApiResponse<T>(result, _errorHandler.GetNotifications());
            return response.Send(_logger);
        }
    }
}
