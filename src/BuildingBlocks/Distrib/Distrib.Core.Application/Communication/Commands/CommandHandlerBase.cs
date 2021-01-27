using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Communication.Mediator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Distrib.Core.Application.Communication.Commands
{
    /// <summary>
    /// Base command handler to be used by all other command handlers.
    /// </summary>
    public abstract class CommandHandlerBase
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="IMediatorHandler"/>.
        /// </summary>
        protected IMediatorHandler MediatorHandler { get; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandlerBase"/> class.
        /// </summary>
        /// <param name="mediatorHandler">The mediator to be used in the common operations.</param>
        protected CommandHandlerBase(
            IMediatorHandler mediatorHandler)
        {
            MediatorHandler = mediatorHandler;
        }

        /// <summary>
        /// Notify errors to the mediator.
        /// </summary>
        /// <param name="errors">Errors to be notified.</param>
        /// <returns>A task that represents the asynchronous notification.</returns>
        protected async Task NotifyErrorsAsync(IEnumerable<ErrorNotification> errors)
        {
            var notifyErrorTasks = new List<Task>();

            foreach (var error in errors)
            {
                notifyErrorTasks.Add(MediatorHandler.NotifyErrorAsync(error));
            }

            await Task.WhenAll(notifyErrorTasks);
        }
    }
}
