using Distrib.Core.Application.Communication.Commands;
using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Communication.Events.IntegrationEvents;
using Distrib.Core.Application.Communication.Mediator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Distrib.Core.Application.Communication.Bus
{
    public abstract class IntegrationHandlerBase<TIntegrationEvent, TCommand, TCommandResult> : BackgroundService
        where TIntegrationEvent : IntegrationEventBase
        where TCommand : CommandBase<TCommandResult>
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public IntegrationHandlerBase(
            IServiceProvider serviceProvider,
            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        protected abstract TCommand ConvertToCommand(TIntegrationEvent integrationEvent);
        protected abstract bool CommandSucceeded(TCommandResult commandResult);

        private void SetResponder()
        {
            _ = _bus.RespondAsync<TIntegrationEvent, ResponseMessage>(
                async request => await EnviarCommand(ConvertToCommand(request)));

            _bus.OnConnected(OnConnect);
        }

        private void OnConnect(object s, EventArgs e) =>
            SetResponder();

        private async Task<ResponseMessage> EnviarCommand(TCommand command)
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();

            var result = await mediator.SendCommandAsync(command);

            // TODO melhorar resposta
            if (CommandSucceeded(result))
            {
                return new ResponseMessage(new List<ErrorNotification>());
            }

            return new ResponseMessage(new List<ErrorNotification>
            {
                new ErrorNotification(
                    HttpStatusCode.BadRequest,
                    command.ToString(),
                    "Algum erro aconteceu no processamento"),
            });
        }
    }
}
