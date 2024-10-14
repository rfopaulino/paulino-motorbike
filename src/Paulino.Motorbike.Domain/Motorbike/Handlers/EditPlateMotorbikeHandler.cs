using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class EditPlateMotorbikeHandler : IRequestHandler<EditPlateMotorbikeRequest, BaseResponse>
    {
        public Task<BaseResponse> Handle(EditPlateMotorbikeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
