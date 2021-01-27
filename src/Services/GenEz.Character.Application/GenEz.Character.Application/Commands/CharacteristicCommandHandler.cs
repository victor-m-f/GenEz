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
    public class CharacteristicCommandHandler : CommandHandlerBase,
        IRequestHandler<CreateCharacteristicCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ICharacteristicRepository _characteristicRepository;

        public CharacteristicCommandHandler(
            IMediatorHandler mediatorHandler,
            IMapper mapper,
            ICharacteristicRepository characteristicRepository)
            : base(mediatorHandler)
        {
            _mapper = mapper;
            _characteristicRepository = characteristicRepository;
        }

        public async Task<bool> Handle(CreateCharacteristicCommand request, CancellationToken cancellationToken)
        {
            var characteristic = _mapper.Map<Characteristic>(request);

            var existingCharacteristics = await _characteristicRepository.GetCharacteristicsByNameAsync(request.OpposedCharacteristics);
            characteristic.InsertOpposedCharacteristics(existingCharacteristics, request.OpposedCharacteristics);

            _characteristicRepository.Create(characteristic);

            return await _characteristicRepository.CommitAsync();
        }
    }
}
