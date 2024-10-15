using MediatR;
using Paulino.Motorbike.Domain.Base;

namespace Paulino.Motorbike.Domain.Rental.Requests
{
    public class SaveRentalRequest(int motorbikeId, int driverId, int planId) : IRequest<BaseResponse>
    {
        public int MotorbikeId { get; } = motorbikeId;
        public int DriverId { get; } = driverId;
        public int PlanId { get; } = planId;
    }
}
