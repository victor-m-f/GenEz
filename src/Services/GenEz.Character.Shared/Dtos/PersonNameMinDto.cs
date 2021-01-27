using System;
using System.Collections.Generic;

namespace GenEz.Character.Shared.Dtos
{
    public class PersonNameMinDto
    {
        #region Properties

        public Guid Id { get; set; }
        public List<SpellingDto> Spellings { get; set; }

        #endregion
    }
}
