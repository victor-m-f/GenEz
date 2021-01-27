using Distrib.Core.Application.Communication.Commands;
using System;
using System.Collections.Generic;

namespace GenEz.Character.Shared.Commands
{
    public class CreatePersonNameCommand : CommandBase<bool>
    {
        #region Properties

        public List<string> Spellings { get; set; }
        public bool IsFirstName { get; set; }
        public bool IsSurname { get; set; }
        public bool IsFemale { get; set; }
        public bool IsMale { get; set; }
        public List<Guid> NameOriginsIds { get; set; }
        public List<Guid> RelatedPersonNamesIds { get; set; }
        public List<string> Nicknames { get; set; }

        #endregion

        #region Constructors

        public CreatePersonNameCommand()
        {
        }

        #endregion
    }
}
