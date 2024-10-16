namespace Paulino.Motorbike.Domain.Rental.Responses
{
    public class GetRentalResponse
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ExpectedEndDate { get; set; }
        public decimal OriginalAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int MotorbikeId { get; set; }
        public int DriverId { get; set; }
        public int PlanId { get; set; }
    }
}
