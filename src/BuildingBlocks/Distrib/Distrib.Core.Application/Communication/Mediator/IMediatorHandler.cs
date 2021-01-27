using Distrib.Core.Application.Communication.Commands;
using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Communication.Events;
using System.Threading.Tasks;

namespace Distrib.Core.Application.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<TResult> SendCommandAsync<TResult>(CommandBase<TResult> command);
        Task NotifyErrorAsync<T>(T error)
            where T : ErrorNotification;
        Task PublishEventAsync<T>(T @event)
            where T : EventBase;
    }
}
