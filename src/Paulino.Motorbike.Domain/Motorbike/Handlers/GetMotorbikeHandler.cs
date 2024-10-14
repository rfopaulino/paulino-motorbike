using MediatR;
using Paulino.Motorbike.Domain.Motorbike.Requests;
using Paulino.Motorbike.Domain.Motorbike.Responses;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class GetMotorbikeHandler : IRequestHandler<GetMotorbikeRequest, GetMotorbikeResponse>
    {
        public Task<GetMotorbikeResponse> Handle(GetMotorbikeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
