using Paulino.Motorbike.Domain.Rental.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Rental.Requests
{
    public class SaveRentalRequestBuilder
    {
        private DateTime _startDate = DateTime.UtcNow.AddDays(1);
        private DateTime _endDate = DateTime.UtcNow.AddDays(7);
        private DateTime _expectedEndDate = DateTime.UtcNow.AddDays(7);
        private decimal _totalAmount = 210;
        private int _motorbikeId = 1;
        private int _driverId = 1;
        private int _planId = 1;

        public SaveRentalRequestBuilder ChangeStartDateTo(DateTime startDate)
        {
            _startDate = startDate;
            return this;
        }

        public SaveRentalRequestBuilder ChangeEndDateTo(DateTime endDate)
        {
            _endDate = endDate;
            return this;
        }

        public SaveRentalRequestBuilder ChangeExpectedEndDateTo(DateTime expectedEndDate)
        {
            _expectedEndDate = expectedEndDate;
            return this;
        }

        public SaveRentalRequestBuilder ChangeTotalAmountTo(decimal totalAmount)
        {
            _totalAmount = totalAmount;
            return this;
        }

        public SaveRentalRequestBuilder ChangeMotorbikeId(int motorbikeId)
        {
            _motorbikeId = motorbikeId;
            return this;
        }

        public SaveRentalRequestBuilder ChangeDriverId(int driverId)
        {
            _driverId = driverId;
            return this;
        }

        public SaveRentalRequestBuilder ChangePlanId(int planId)
        {
            _planId = planId;
            return this;
        }

        public SaveRentalRequest Build()
        {
            return new SaveRentalRequest(_motorbikeId, _driverId, _planId);
        }
    }
}
