using MediatR;
using Paulino.Motorbike.Domain.Rental.Responses;

namespace Paulino.Motorbike.Domain.Rental.Requests
{
    public class GetByIdRentalRequest(int id) : IRequest<GetByIdRentalResponse>
    {
        public int Id { get; } = id;
    }
}
