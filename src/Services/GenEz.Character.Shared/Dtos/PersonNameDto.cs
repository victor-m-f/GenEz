using System;
using System.Collections.Generic;

namespace GenEz.Character.Shared.Dtos
{
    public class PersonNameDto
    {
        #region Properties

        public Guid Id { get; set; }
        public List<SpellingDto> Spellings { get; set; }
        public bool IsFirstName { get; set; }
        public bool IsSurname { get; set; }
        public bool IsFemale { get; set; }
        public bool IsMale { get; set; }
        public List<NameOriginDto> NameOrigins { get; set; }
        public List<PersonNameMinDto> RelatedPersonNames { get; set; }
        public List<NicknameDto> Nicknames { get; set; }

        #endregion
    }
}
