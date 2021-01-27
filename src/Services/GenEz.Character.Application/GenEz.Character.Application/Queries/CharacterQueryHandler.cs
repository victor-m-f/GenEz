using AutoMapper;
using GenEz.Character.Domain.Repositories;
using GenEz.Character.Shared.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenEz.Character.Application.Queries
{
    public class CharacterQueryHandler : ICharacterQueryHandler
    {
        private readonly IMapper _mapper;
        private readonly INameOriginRepository _nameOriginRepository;
        private readonly IPersonNameRepository _personNameRepository;
        private readonly ICharacteristicRepository _characteristicRepository;
        private readonly IReligionRepository _religionRepository;
        private readonly IEthinicityRepository _ethinicityRepository;
        private readonly ISocialClassRepository _socialClassRepository;
        private readonly ISexualOrientationRepository _sexualOrientationRepository;

        public CharacterQueryHandler(
            IMapper mapper,
            INameOriginRepository nameOriginRepository,
            IPersonNameRepository personNameRepository,
            ICharacteristicRepository characteristicRepository,
            IReligionRepository religionRepository,
            IEthinicityRepository ethinicityRepository,
            ISocialClassRepository socialClassRepository,
            ISexualOrientationRepository sexualOrientationRepository)
        {
            _mapper = mapper;
            _nameOriginRepository = nameOriginRepository;
            _personNameRepository = personNameRepository;
            _characteristicRepository = characteristicRepository;
            _religionRepository = religionRepository;
            _ethinicityRepository = ethinicityRepository;
            _socialClassRepository = socialClassRepository;
            _sexualOrientationRepository = sexualOrientationRepository;
        }

        public async Task<IEnumerable<NameOriginDto>> GetAllNameOriginsAsync()
        {
            return (await _nameOriginRepository.GetAllAsync()).Select(x => _mapper.Map<NameOriginDto>(x));
        }

        public async Task<IEnumerable<PersonNameDto>> GetAllPersonNamesAsync()
        {
            return (await _personNameRepository.GetAllAsync()).Select(x => _mapper.Map<PersonNameDto>(x));
        }

        public async Task<IEnumerable<CharacteristicDto>> GetAllCharacteristicsAsync()
        {
            return (await _characteristicRepository.GetAllAsync()).Select(x => _mapper.Map<CharacteristicDto>(x));
        }

        public async Task<IEnumerable<ReligionDto>> GetAllReligionsAsync()
        {
            return (await _religionRepository.GetAllAsync()).Select(x => _mapper.Map<ReligionDto>(x));
        }

        public async Task<IEnumerable<EthnicityDto>> GetAllEthnicitiesAsync()
        {
            return (await _ethinicityRepository.GetAllAsync()).Select(x => _mapper.Map<EthnicityDto>(x));
        }

        public async Task<IEnumerable<SocialClassDto>> GetAllSocialClassesAsync()
        {
            return (await _socialClassRepository.GetAllAsync()).Select(x => _mapper.Map<SocialClassDto>(x));
        }

        public async Task<IEnumerable<SexualOrientationDto>> GetAllSexOrientationsAsync()
        {
            return (await _sexualOrientationRepository.GetAllAsync()).Select(x => _mapper.Map<SexualOrientationDto>(x));
        }
    }
}
