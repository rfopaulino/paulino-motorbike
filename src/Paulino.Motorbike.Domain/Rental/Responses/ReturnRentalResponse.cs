namespace Paulino.Motorbike.Domain.Rental.Responses
{
    public class ReturnRentalResponse
    {
        public ReturnRentalResponse(decimal totalAmount, decimal fineAmount)
        {
            TotalAmount = totalAmount;
            FineAmount = fineAmount;
        }

        public decimal TotalAmount { get; }
        public decimal FineAmount { get; }
    }
}
