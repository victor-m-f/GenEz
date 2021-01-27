using Distrib.Core.Domain;
using Distrib.Helper.Extensions;
using System.Collections.Generic;

namespace GenEz.Character.Domain.Entities
{
    public class Nickname : EntityBase
    {
        #region Properties

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value.Trim().ToTitleCase();
            }
        }
        public ICollection<PersonName> PersonNames { get; set; }

        #endregion

        #region Constructors

        public Nickname(string name)
        {
            Name = name;
        }

        // Required for entity framework
        private Nickname()
        {
        }

        #endregion
    }
}
