using Paulino.Motorbike.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Motorbike.Requests
{
    public class EditPlateMotorbikeRequestBuilder
    {
        private string _plate = "ABC-1234";
        private int _motorbikeId = 1;

        public EditPlateMotorbikeRequestBuilder ChangePlateTo(string plate)
        {
            _plate = plate;
            return this;
        }

        public EditPlateMotorbikeRequestBuilder ChangeMotorbikeId(int motorbikeId)
        {
            _motorbikeId = motorbikeId;
            return this;
        }

        public EditPlateMotorbikeRequest Build()
        {
            return new EditPlateMotorbikeRequest(_plate, _motorbikeId);
        }
    }
}
