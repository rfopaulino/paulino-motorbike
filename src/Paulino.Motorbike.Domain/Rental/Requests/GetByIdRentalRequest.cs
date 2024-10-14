using MediatR;

namespace Paulino.Motorbike.Domain.Rental.Requests
{
    public class GetByIdRentalRequest(int id) : IRequest<Unit>
    {
        public int Id { get; } = id;
    }
}
