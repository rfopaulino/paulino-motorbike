using MediatR;
using Paulino.Motorbike.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.Domain.Motorbike.Handlers
{
    public class DeleteByIdMotorbikeHandler : IRequestHandler<DeleteByIdMotorbikeRequest, Unit>
    {
        public Task<Unit> Handle(DeleteByIdMotorbikeRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
