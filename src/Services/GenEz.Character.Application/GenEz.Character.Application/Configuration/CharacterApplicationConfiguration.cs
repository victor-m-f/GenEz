using Distrib.Core.Application.Configuration.General;
using GenEz.Character.Application.Commands;
using GenEz.Character.Application.Queries;
using GenEz.Character.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace GenEz.Character.Application.Configuration
{
    public static class CharacterApplicationConfiguration
    {
        public static void ConfigureCharacterApplication(this IServiceCollection services)
        {
            services.InjectDependencies();
        }

        private static void InjectDependencies(this IServiceCollection services)
        {
            // Commands
            services.AddCommand<CreatePersonNameCommand, bool, PersonNameCommandHandler>();
            services.AddCommand<CreateNameOriginCommand, bool, NameOriginCommandHandler>();
            services.AddCommand<CreateCharacteristicCommand, bool, CharacteristicCommandHandler>();

            // Queries
            services.AddScoped<ICharacterQueryHandler, CharacterQueryHandler>();
        }
    }
}
