using System;

namespace GenEz.Character.Shared.Dtos
{
    public class ReligionDto
    {
        #region Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsFictional { get; set; }
        public string Adjective { get; set; }

        #endregion
    }
}
