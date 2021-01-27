using Distrib.Core.Domain;
using System;

namespace GenEz.Character.Domain.Entities
{
    public class SocialClass : EntityBase
    {
        public const int NameMaxSize = 10;

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

        #endregion

        #region Constructors

        public SocialClass(Guid id, string name)
            : base(id)
        {
            Name = name;
        }

        // Required for entity framework
        private SocialClass()
        {
        }

        #endregion
    }
}