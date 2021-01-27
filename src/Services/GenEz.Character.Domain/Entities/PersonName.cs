using Distrib.Core.Domain;
using System.Collections.Generic;
using System.Linq;

namespace GenEz.Character.Domain.Entities
{
    public class PersonName : EntityBase
    {
        #region Properties

        public ICollection<Spelling> Spellings { get; set; }
        public bool IsFirstName { get; set; }
        public bool IsSurname { get; set; }
        public bool IsFemale { get; set; }
        public bool IsMale { get; set; }
        public ICollection<NameOrigin> NameOrigins { get; set; }
        public ICollection<PersonName> RelatedPersonNamesTo { get; set; }
        public ICollection<PersonName> RelatedPersonNamesFrom { get; set; }
        public ICollection<Nickname> Nicknames { get; set; }

        #endregion

        #region Constructors

        public PersonName()
        {
        }

        #endregion

        public void InsertNicknames(List<Nickname> existingNicknames, List<string> allNicknames)
        {
            var newNicknames = allNicknames.Where(x => !existingNicknames.Select(y => y.Name).Contains(x)).Select(x => new Nickname(x));
            Nicknames = existingNicknames.Union(newNicknames).ToList();
        }
    }
}
