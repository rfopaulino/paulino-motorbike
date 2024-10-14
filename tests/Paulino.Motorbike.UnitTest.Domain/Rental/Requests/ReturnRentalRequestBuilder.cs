using Paulino.Motorbike.Domain.Rental.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Rental.Requests
{
    public class ReturnRentalRequestBuilder
    {
        private DateTime _date = DateTime.UtcNow;
        private int _rentalId = 1;

        public ReturnRentalRequestBuilder ChangeDateTo(DateTime date)
        {
            _date = date;
            return this;
        }

        public ReturnRentalRequestBuilder ChangeRentalIdTo(int rentalId)
        {
            _rentalId = rentalId;
            return this;
        }

        public ReturnRentalRequest Build()
        {
            return new ReturnRentalRequest(_date, _rentalId);
        }
    }
}
