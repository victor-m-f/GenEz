using Distrib.Core.Domain;
using Distrib.Helper.Extensions;
using System;

namespace GenEz.Character.Domain.Entities
{
    public sealed class Education : EntityBase
    {
        public const int NameMaxSize = 25;

        #region Properties

        private string _name;
        public string Name
        {
            get => _name;
            private set
            {
                _name = value.Trim().ToLower();
            }
        }
        public byte MinimumAge { get; private set; }
        public byte YearsToComplete { get; private set; }
        private string _title;
        public string Title
        {
            get => _title;
            private set
            {
                _title = value?.Trim().OnlyFirstToUpper();
            }
        }
        private string _abbreviation;
        public string Abbreviation
        {
            get => _abbreviation;
            private set
            {
                _abbreviation = value?.Trim().OnlyFirstToUpper();
            }
        }

        #endregion

        #region Constructors

        public Education(Guid id, string name, byte minimumAge, byte yearsToComplete, string title, string abbreviation)
          : base(id)
        {
            Name = name;
            MinimumAge = minimumAge;
            YearsToComplete = yearsToComplete;
            Title = title;
            Abbreviation = abbreviation;
        }

        // Required for entity framework
        private Education()
        {
        }

        #endregion

        #region Entity Methods

        public override string ToString() => Name;

        #endregion
    }
}