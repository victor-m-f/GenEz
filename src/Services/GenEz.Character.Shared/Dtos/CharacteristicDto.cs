using System;
using System.Collections.Generic;

namespace GenEz.Character.Shared.Dtos
{
    public class CharacteristicDto
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? IsPositive { get; set; }
        public List<CharacteristicMinDto> OpposedCharacteristics { get; set; }

        #endregion
    }
}
