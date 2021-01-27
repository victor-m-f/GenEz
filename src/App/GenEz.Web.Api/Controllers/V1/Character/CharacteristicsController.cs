using Distrib.Core.Api.Controllers;
using Distrib.Core.Api.Controllers.Responses;
using Distrib.Core.Application.Communication.Errors;
using Distrib.Core.Application.Communication.Mediator;
using GenEz.Character.Application.Queries;
using GenEz.Character.Shared.Commands;
using GenEz.Character.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenEz.Web.Api.Controllers.V1.Character
{
    public class CharacteristicsController : ApiControllerBase
    {
        private readonly ICharacterQueryHandler _characterQueryHandler;

        public CharacteristicsController(
            ILogger<PersonNamesController> logger,
            INotificationHandler<ErrorNotification> errorHandler,
            IMediatorHandler mediator,
            ICharacterQueryHandler characterQueryHandler)
            : base(logger, errorHandler, mediator)
        {
            _characterQueryHandler = characterQueryHandler;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ApiResponseWithResult<IEnumerable<CharacteristicDto>>>> GetAll()
        {
            return Respond(await _characterQueryHandler.GetAllCharacteristicsAsync());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> Create(CreateCharacteristicCommand command)
        {
            await Mediator.SendCommandAsync(command);
            return Respond();
        }

        //[AllowAnonymous]
        //[HttpPut]
        //public async Task<ActionResult<ApiResponseWithResult<Carro>>> Update(string carPlate)
        //{
        //    return Respond(await _carrosService.GetCarroPorPlacaAsync(carPlate));
        //}

        //[AllowAnonymous]
        //[HttpDelete]
        //public async Task<ActionResult<ApiResponseWithResult<Carro>>> Delete(string carPlate)
        //{
        //    return Respond(await _carrosService.GetCarroPorPlacaAsync(carPlate));
        //}
    }
}
