using MediatR;
using Paulino.Motorbike.Domain.Base;
using Paulino.Motorbike.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class SaveMotorbikeHandler : IRequestHandler<SaveMotorbikeRequest, BaseResponse>
    {
        public Task<BaseResponse> Handle(SaveMotorbikeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
