using Distrib.Core.Domain;
using Distrib.Helper.Extensions;
using System;

namespace GenEz.Character.Domain.Entities
{
    public class Religion : EntityBase
    {
        public const int NameMaxSize = 15;
        public const int AdjectiveMaxSize = 10;

        #region Properties

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value.Trim().ToTitleCase();
                NeutralText = _name.ToNeutral();
            }
        }
        public string NeutralText { get; set; }
        public bool IsFictional { get; set; }
        private string _adjective;
        public string Adjective
        {
            get => _adjective;
            set
            {
                _adjective = value.ToLower();
            }
        }

        #endregion

        #region Constructors

        public Religion(Guid id, string name, bool isFictional, string adjective)
            : base(id)
        {
            Name = name;
            IsFictional = isFictional;
            Adjective = adjective;
        }

        // Required for entity framework
        private Religion()
        {
        }

        #endregion
    }
}