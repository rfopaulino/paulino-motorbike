using MediatR;

namespace Paulino.Motorbike.Domain.Rental.Requests
{
    public class GetRentalRequest(int? motorbikeId, int? driverId) : IRequest<Unit>
    {
        public int? MotorbikeId { get; } = motorbikeId;
        public int? DriverId { get; } = driverId;
    }
}
