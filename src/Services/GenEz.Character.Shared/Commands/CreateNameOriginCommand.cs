using Distrib.Core.Application.Communication.Commands;

namespace GenEz.Character.Shared.Commands
{
    public class CreateNameOriginCommand : CommandBase<bool>
    {
        #region Properties

        public string Name { get; set; }

        #endregion

        #region Constructors

        public CreateNameOriginCommand()
        {
        }

        #endregion
    }
}
