namespace Paulino.Motorbike.Domain.Rental.Responses
{
    public class GetByIdRentalResponse
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ExpectedEndDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
