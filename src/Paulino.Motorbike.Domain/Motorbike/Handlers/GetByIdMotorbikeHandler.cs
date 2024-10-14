using MediatR;
using Paulino.Motorbike.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class GetByIdMotorbikeHandler : IRequestHandler<GetByIdMotorbikeRequest, GetByIdMotorbikeRequest>
    {
        public Task<GetByIdMotorbikeRequest> Handle(GetByIdMotorbikeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
