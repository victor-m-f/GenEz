using Distrib.Core.Domain;
using Distrib.Helper.Extensions;
using System;
using System.Collections.Generic;

namespace GenEz.Character.Domain.Entities
{
    public class NameOrigin : EntityBase
    {
        #region Properties

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value.Trim().ToTitleCase();
                NeutralName = _name.ToNeutral();
            }
        }
        public string NeutralName { get; set; }
        public ICollection<PersonName> PersonNames { get; set; }

        #endregion

        #region NameOrigin

        public NameOrigin(Guid id, string name)
            : base(id)
        {
            Name = name;
        }

        #endregion
    }
}
