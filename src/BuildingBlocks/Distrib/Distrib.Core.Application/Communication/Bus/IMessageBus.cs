using Distrib.Core.Application.Communication.Events.IntegrationEvents;
using System;
using System.Threading.Tasks;

namespace Distrib.Core.Application.Communication.Bus
{
    public interface IMessageBus : IDisposable
    {
        void Publish<T>(T message)
            where T : IntegrationEventBase;
        Task PublishAsync<T>(T message)
            where T : IntegrationEventBase;
        void Subscribe<T>(string subscriptionId, Action<T> onMessage)
            where T : class;
        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage)
            where T : class;
        TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEventBase
            where TResponse : ResponseMessage;
        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : IntegrationEventBase
            where TResponse : ResponseMessage;
        IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : IntegrationEventBase
            where TResponse : ResponseMessage;

        IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : IntegrationEventBase
            where TResponse : ResponseMessage;

        bool IsConnected { get; }

        void OnConnected(EventHandler eventToExecute);
    }
}
