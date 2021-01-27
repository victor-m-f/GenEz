using Distrib.Core.Application.Communication;
using Distrib.Core.Application.Communication.Errors;
using System.Collections.Generic;
using System.Linq;

namespace Distrib.Core.Application.Communication.Events.IntegrationEvents
{
    public class ResponseMessage : MessageBase
    {
        #region Properties

        public bool IsValid => !(Errors?.Any() == true);
        public List<ErrorNotification> Errors { get; private set; }

        #endregion

        public ResponseMessage(List<ErrorNotification> errors)
        {
            Errors = errors;
        }
    }
}
