using System;

namespace GenEz.Character.Shared.Dtos
{
    public class SexualOrientationDto
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? PreferOppositeSex { get; set; }
        public bool? PreferFemale { get; set; }

        #endregion
    }
}
