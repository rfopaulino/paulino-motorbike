using MediatR;
using Paulino.Motorbike.Domain.Base;

namespace Paulino.Motorbike.Domain.Rental.Requests
{
    public class SaveRentalRequest(DateTime startDate, DateTime endDate, DateTime expectedEndDate, decimal totalAmount, int motorbikeId, int driverId, int planId) : IRequest<BaseResponse>
    {
        public DateTime StartDate { get; } = startDate;
        public DateTime EndDate { get; } = endDate;
        public DateTime ExpectedEndDate { get; } = expectedEndDate;
        public decimal TotalAmount { get; } = totalAmount;
        public int MotorbikeId { get; } = motorbikeId;
        public int DriverId { get; } = driverId;
        public int PlanId { get; } = planId;
    }
}
