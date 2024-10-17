using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Paulino.Motorbike.Api.Mediator
{
    public static class MediatorActionResult
    {
        public static async Task<IActionResult> SendActionResult(this IMediator mediator, IBaseRequest request, StatusCodeSuccess code = StatusCodeSuccess.OK)
        {
            try
            {
                var result = await mediator.Send(request);

                if (code == StatusCodeSuccess.Created)
                {
                    return new CreatedResult(default(string?), result);
                }
                else
                {
                    return new OkObjectResult(result);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
