using MediatR;
using Paulino.Motorbike.Domain.Rental.Requests;

namespace Paulino.Motorbike.Domain.Rental.Handlers
{
    public class GetRentalHandler : IRequestHandler<GetRentalRequest, Unit>
    {
        public Task<Unit> Handle(GetRentalRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
