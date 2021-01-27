using Distrib.Core.Data.Configuration;
using GenEz.Character.Data.Repositories;
using GenEz.Character.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GenEz.Character.Data.Configuration
{
    public static class CharacterDataConfiguration
    {
        public static void ConfigureCharacterData(this IServiceCollection services, IConfiguration configuration)
        {
            services.UseDefaultConnection<CharacterDbContext>(configuration);

            _ = services.AddScoped<IPersonNameRepository, PersonNameRepository>();
            _ = services.AddScoped<INameOriginRepository, NameOriginRepository>();
            _ = services.AddScoped<ICharacteristicRepository, CharacteristicRepository>();
            _ = services.AddScoped<IReligionRepository, ReligionRepository>();
            _ = services.AddScoped<IEthinicityRepository, EthinicityRepository>();
            _ = services.AddScoped<ISocialClassRepository, SocialClassRepository>();
            _ = services.AddScoped<ISexualOrientationRepository, SexualOrientationRepository>();
        }
    }
}
