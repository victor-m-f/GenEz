using MediatR;
using System;

namespace Distrib.Core.Application.Communication.Commands
{
    public abstract class CommandBase<T> : MessageBase, IRequest<T>
    {
        protected DateTime Date { get; }

        protected CommandBase()
        {
            Date = DateTime.Now;
        }
    }
}
