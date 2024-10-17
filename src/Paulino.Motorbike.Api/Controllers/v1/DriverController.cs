using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paulino.Motorbike.Api.Mediator;
using Paulino.Motorbike.Domain.Driver.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace Paulino.Motorbike.Api.Controllers.v1
{
    [Authorize(Roles = "admin")]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DriverController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "driver")]
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastrar entregador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Save(SaveDriverRequest request) =>
            await _mediator.SendActionResult(request);

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Consultar entregadores existentes por id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id) =>
            await _mediator.SendActionResult(new GetByIdDriverRequest(id));

        [HttpGet]
        [SwaggerOperation(Summary = "Consultar entregadores existentes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] string? cnh , [FromQuery] string? cnpj) =>
            await _mediator.SendActionResult(new GetDriverRequest(cnh, cnpj));

        [Authorize(Roles = "driver")]
        [HttpPost("{id}/cnh")]
        [SwaggerOperation(Summary = "Enviar foto da CNH")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendCNH(int id, SendCNHDriverRequest request) =>
            await _mediator.SendActionResult(new SendCNHDriverRequest(id, request.Image));
    }
}
