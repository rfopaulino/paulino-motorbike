using MediatR;
using Paulino.Motorbike.Domain.Rental.Responses;

namespace Paulino.Motorbike.Domain.Rental.Requests
{
    public class GetRentalRequest(int? motorbikeId, int? driverId) : IRequest<List<GetRentalResponse>>
    {
        public int? MotorbikeId { get; } = motorbikeId;
        public int? DriverId { get; } = driverId;
    }
}
