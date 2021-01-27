using Distrib.Core.Domain;
using System;

namespace GenEz.Character.Domain.Entities
{
    public class SexualOrientation : EntityBase
    {
        public const int NameMaxSize = 11;

        #region Properties

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value.Trim().ToLower();
            }
        }
        public bool? PreferOppositeSex { get; set; }
        public bool? PreferFemale { get; set; }

        #endregion

        #region Constructors

        public SexualOrientation(Guid id, string name, bool? preferOppositeSex, bool? preferFemale)
            : base(id)
        {
            Name = name;
            PreferOppositeSex = preferOppositeSex;
            PreferFemale = preferFemale;

        }

        // Required for entity framework
        private SexualOrientation()
        {
        }

        #endregion
    }
}
