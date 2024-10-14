using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paulino.Motorbike.Api.Mediator;
using Paulino.Motorbike.Domain.Rental.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace Paulino.Motorbike.Api.Controllers.v1
{
    [Route("v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Alugar uma moto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save(SaveRentalRequest request) =>
            await _mediator.SendActionResult(request);

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consultar locações existentes por id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id) =>
            await _mediator.SendActionResult(new GetByIdRentalRequest(id));

        [HttpGet]
        [SwaggerOperation(Summary = "Consultar locações existentes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] int? motorbikeId, [FromQuery] int? driverId) =>
            await _mediator.SendActionResult(new GetRentalRequest(motorbikeId, driverId));

        [HttpPut("{id}/return")]
        [SwaggerOperation(Summary = "Devolver uma moto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Return(int id, ReturnRentalRequest request) =>
            await _mediator.SendActionResult(new ReturnRentalRequest(request.Date, id));
    }
}
