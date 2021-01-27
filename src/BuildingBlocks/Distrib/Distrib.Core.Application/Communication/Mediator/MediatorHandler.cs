using Distrib.Core.Application.Communication.Commands;
using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Communication.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Distrib.Core.Application.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MediatorHandler> _logger;

        public MediatorHandler(IMediator mediator, ILogger<MediatorHandler> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<TResult> SendCommandAsync<TResult>(CommandBase<TResult> command)
        {
            _logger.LogInformation("Command {@command} sent.", command);
            var result = await _mediator.Send(command);
            return result;
        }

        public async Task NotifyErrorAsync<T>(T error)
            where T : ErrorNotification
        {
            _logger.LogWarning("Error {@error} notified.", error);
            await _mediator.Publish(error);
        }

        public async Task PublishEventAsync<T>(T @event)
            where T : EventBase
        {
            _logger.LogInformation("Event {@event} published.", @event);
            await _mediator.Publish(@event);
        }
    }
}
