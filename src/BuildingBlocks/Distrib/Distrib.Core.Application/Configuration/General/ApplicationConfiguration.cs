using Distrib.Core.Application.Communication.Commands;
using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Communication.Mediator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Distrib.Core.Application.Configuration.General
{
    /// <summary>
    /// Exposes methods for configuring Application projects.
    /// </summary>
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds the mediator pattern.
        /// </summary>
        /// <param name="services">The collection of services the mediator will be configured.</param>
        /// <param name="startupTypeToConfigure">The type Startup that will be configured.</param>
        public static void AddMediatorConfiguration(this IServiceCollection services, Type startupTypeToConfigure)
        {
            _ = services.AddMediatR(startupTypeToConfigure);
            _ = services.AddScoped<IMediatorHandler, MediatorHandler>();
            _ = services.AddScoped<INotificationHandler<ErrorNotification>, ErrorHandler>();
        }

        /// <summary>
        /// Adds a command and the handler that will manage it.
        /// </summary>
        /// <typeparam name="TCommand">The command to be handled.</typeparam>
        /// <typeparam name="TResponse">The expected response after executing the command.</typeparam>
        /// <typeparam name="TCommandHandler">The <see cref="CommandHandlerBase"/> that will handle the command.</typeparam>
        /// <param name="services">The collection of services where this command will be available.</param>
        public static void AddCommand<TCommand, TResponse, TCommandHandler>(this IServiceCollection services)
            where TCommand : CommandBase<TResponse>
            where TCommandHandler : CommandHandlerBase, IRequestHandler<TCommand, TResponse> =>
            _ = services.AddScoped<IRequestHandler<TCommand, TResponse>, TCommandHandler>();
    }
}
