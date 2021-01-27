using AutoMapper;
using Distrib.Core.Application.Communication.Commands;
using Distrib.Core.Application.Communication.Mediator;
using GenEz.Character.Domain.Entities;
using GenEz.Character.Domain.Repositories;
using GenEz.Character.Shared.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GenEz.Character.Application.Commands
{
    public class PersonNameCommandHandler : CommandHandlerBase,
        IRequestHandler<CreatePersonNameCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IPersonNameRepository _personNameRepository;
        private readonly INameOriginRepository _nameOriginRepository;

        public PersonNameCommandHandler(
            IMediatorHandler mediatorHandler,
            IMapper mapper,
            IPersonNameRepository personNameRepository,
            INameOriginRepository nameOriginRepository)
            : base(mediatorHandler)
        {
            _mapper = mapper;
            _personNameRepository = personNameRepository;
            _nameOriginRepository = nameOriginRepository;
        }

        public async Task<bool> Handle(CreatePersonNameCommand request, CancellationToken cancellationToken)
        {
            var personName = _mapper.Map<PersonName>(request);

            personName.NameOrigins = await _nameOriginRepository.GetNameOriginsByIdsAsync(request.NameOriginsIds);
            personName.RelatedPersonNamesTo = await _personNameRepository.GetPersonNamesByIdsAsync(request.RelatedPersonNamesIds);
            var existingNicknames = await _personNameRepository.GetNicknamesByNameAsync(request.Nicknames);
            personName.InsertNicknames(existingNicknames, request.Nicknames);

            _personNameRepository.Create(personName);

            return await _personNameRepository.CommitAsync();
        }
    }
}
