using Distrib.Core.Application.Communication.Commands;
using System.Collections.Generic;

namespace GenEz.Character.Shared.Commands
{
    public class CreateCharacteristicCommand : CommandBase<bool>
    {
        #region Properties

        public string Name { get; set; }
        public bool? IsPositive { get; set; }
        public List<string> OpposedCharacteristics { get; set; }

        #endregion

        #region Constructors

        public CreateCharacteristicCommand()
        {
        }

        #endregion
    }
}
