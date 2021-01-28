using AutoMapper;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Shared.Commands;
using GenEz.Character.Shared.Dtos;
using System.Linq;

namespace GenEz.Character.Domain.Configuration
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            _ = CreateMap<CreatePersonNameCommand, PersonName>()
                .ForMember(dest => dest.Nicknames, opt => opt.Ignore())
                .ForMember(dest => dest.Spellings, opt => opt.MapFrom(src => src.Spellings.Select(x => new Spelling(x))));
            _ = CreateMap<PersonName, PersonNameDto>()
                .ForMember(dest => dest.RelatedPersonNames, opt => opt.MapFrom(src => src.RelatedPersonNamesFrom.Union(src.RelatedPersonNamesTo)));
            _ = CreateMap<PersonName, PersonNameMinDto>();

            _ = CreateMap<CreateNameOriginCommand, NameOrigin>();
            _ = CreateMap<NameOrigin, NameOriginDto>();

            _ = CreateMap<Nickname, NicknameDto>();

            _ = CreateMap<Spelling, SpellingDto>();

            _ = CreateMap<CreateCharacteristicCommand, Characteristic>();
            _ = CreateMap<Characteristic, CharacteristicDto>()
                .ForMember(dest => dest.OpposedCharacteristics, opt => opt.MapFrom(src => src.CharacteristicsOpposedFrom.Union(src.CharacteristicsOpposedTo)));
            _ = CreateMap<Characteristic, CharacteristicMinDto>();

            _ = CreateMap<Religion, ReligionDto>();

            _ = CreateMap<Ethnicity, EthnicityDto>();

            _ = CreateMap<SocialClass, SocialClassDto>();

            _ = CreateMap<SexualOrientation, SexualOrientationDto>();
            
            _ = CreateMap<Education, EducationDto>();
        }
    }
}
