using System;

namespace GenEz.Character.Shared.Dtos
{
    public class CharacteristicMinDto
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? IsPositive { get; set; }

        #endregion
    }
}
