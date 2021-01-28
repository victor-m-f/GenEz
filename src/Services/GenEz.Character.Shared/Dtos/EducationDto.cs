using System;

namespace GenEz.Character.Shared.Dtos
{
    public class EducationDto
    {
        #region Properties

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public byte MinimumAge { get; private set; }
        public byte YearsToComplete { get; private set; }
        public string Title { get; private set; }
        public string Abbreviation { get; private set; }

        #endregion
    }
}