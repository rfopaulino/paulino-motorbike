

using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Infra.CrossCutting.Exceptions;

namespace Paulino.Motorbike.Api.Mediator
{
    public static class MediatorActionResult
    {
        public static async Task<IActionResult> SendActionResult(this IMediator mediator, IBaseRequest request, AbstractValidator<IBaseRequest>? validator = null, StatusCodeSuccess code = StatusCodeSuccess.OK)
        {
            try
            {
                validator?.Validate(request);
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

                throw;
            }
        }
    }
}
