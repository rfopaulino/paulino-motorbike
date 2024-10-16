using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Infra.CrossCutting.Exception;

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
                    return new CreatedResult();
                }
                else
                {
                    return new OkObjectResult(result);
                }
            }
            catch (Exception ex)
            {
                var baseResponse = new BaseResponse(false, ex.Message);

                if (ex is BadRequestException)
                {
                    return new BadRequestObjectResult(baseResponse);
                }
                else if (ex is NotFoundException)
                {
                    return new NotFoundResult();
                }
                else if (ex is ValidationException)
                {
                    return new BadRequestObjectResult(baseResponse);

                }

                throw;
            }
        }
    }
}
