using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paulino.Motorbike.Api.Mediator;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace Paulino.Motorbike.Api.Controllers.v1
{
    [Authorize]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MotorbikeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MotorbikeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastrar uma nova moto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save(SaveMotorbikeRequest request) =>
            await _mediator.SendActionResult(request);

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consultar motos existentes por id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id) =>
            await _mediator.SendActionResult(new GetByIdMotorbikeRequest(id));

        [HttpGet]
        [SwaggerOperation(Summary = "Consultar motos existentes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] int? year, [FromQuery] string? model, [FromQuery] string? plate) =>
            await _mediator.SendActionResult(new GetMotorbikeRequest(year, model, plate));

        [Authorize(Roles = "admin")]
        [HttpPut("{id}/plate")]
        [SwaggerOperation(Summary = "Modificar a placa de uma moto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditPlate(int id, EditPlateMotorbikeRequest request) =>
            await _mediator.SendActionResult(new EditPlateMotorbikeRequest(request.Plate, id));

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remover uma moto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteById(int id) =>
            await _mediator.SendActionResult(new DeleteByIdMotorbikeRequest(id));
    }
}
