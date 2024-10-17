using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paulino.Motorbike.Api.Mediator;
using Paulino.Motorbike.Domain.Plan.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace Paulino.Motorbike.Api.Controllers.v1
{
    [Authorize]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Consultar planos existentes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] int? motorbikeId, [FromQuery] int? driverId) =>
            await _mediator.SendActionResult(new GetPlanRequest());
    }
}
