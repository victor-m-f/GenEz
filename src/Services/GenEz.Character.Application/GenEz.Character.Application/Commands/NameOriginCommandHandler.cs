using AutoMapper;
using Distrib.Core.Application.Communication.Commands;
using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Communication.Mediator;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using GenEz.Character.Shared.Commands;
using MediatR;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GenEz.Character.Application.Commands
{
    public class NameOriginCommandHandler : CommandHandlerBase,
        IRequestHandler<CreateNameOriginCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly INameOriginRepository _nameOriginRepository;

        public NameOriginCommandHandler(
            IMediatorHandler mediatorHandler,
            IMapper mapper,
            INameOriginRepository nameOriginRepository)
            : base(mediatorHandler)
        {
            _mapper = mapper;
            _nameOriginRepository = nameOriginRepository;
        }

        public async Task<bool> Handle(CreateNameOriginCommand request, CancellationToken cancellationToken)
        {
            if (await _nameOriginRepository.NameOriginsExists(request.Name))
            {
                await MediatorHandler.NotifyErrorAsync(
                    new ErrorNotification(HttpStatusCode.BadRequest, nameof(CreateNameOriginCommand), $"{typeof(NameOrigin)} {request.Name} já existe."));
                return false;
            }

            var nameOrigin = _mapper.Map<NameOrigin>(request);

            _nameOriginRepository.Create(nameOrigin);

            return await _nameOriginRepository.CommitAsync();
        }
    }
}
