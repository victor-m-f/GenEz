using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace GenEz.Character.Domain.Configuration
{
    public static class CharacterDomainConfiguration
    {
        public static void ConfigureCharacterDomain(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMappingProfile));
        }
    }
}
