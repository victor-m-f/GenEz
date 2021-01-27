using Distrib.Helper.Extensions;
using MediatR;
using System;

namespace Distrib.Core.Application.Communication.Events
{
    public abstract class EventBase : MessageBase, INotification
    {
        #region Properties

        public string Name { get; }
        public DateTime Date { get; }

        #endregion

        #region Constructors

        public EventBase()
        {
            Date = DateTime.Now;
            Name = GetType().Name
                    .RemoveText("Event")
                    .RemoveText("Integration")
                    .SeparateCamelCase()
                    .OnlyFirstToUpper();
        }

        #endregion
    }
}
