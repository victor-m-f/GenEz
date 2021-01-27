using GenEz.Character.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Character.Application.Queries
{
    public interface ICharacterQueryHandler
    {
        public Task<IEnumerable<NameOriginDto>> GetAllNameOriginsAsync();
        public Task<IEnumerable<PersonNameDto>> GetAllPersonNamesAsync();
        public Task<IEnumerable<CharacteristicDto>> GetAllCharacteristicsAsync();
        public Task<IEnumerable<ReligionDto>> GetAllReligionsAsync();
        public Task<IEnumerable<EthnicityDto>> GetAllEthnicitiesAsync();
        public Task<IEnumerable<SocialClassDto>> GetAllSocialClassesAsync();
        public Task<IEnumerable<SexualOrientationDto>> GetAllSexOrientationsAsync();
    }
}
