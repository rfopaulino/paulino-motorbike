using MediatR;
using Paulino.Motorbike.Domain.Rental.Requests;

namespace Paulino.Motorbike.Domain.Rental.Handlers
{
    public class GetByIdRentalHandler : IRequestHandler<GetByIdRentalRequest, Unit>
    {
        public Task<Unit> Handle(GetByIdRentalRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
