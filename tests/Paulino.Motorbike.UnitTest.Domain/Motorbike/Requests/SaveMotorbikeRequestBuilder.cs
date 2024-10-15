using Paulino.Motorbike.Domain.Motorbike.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Motorbike.Requests
{
    public class SaveMotorbikeRequestBuilder
    {
        private int _year = 2024;
        private string _model = "sport";
        private string _plate = "ABC1234";

        public SaveMotorbikeRequestBuilder ChangeYearTo(int year)
        {
            _year = year;
            return this;
        }

        public SaveMotorbikeRequestBuilder ChangeModelTo(string model)
        {
            _model = model;
            return this;
        }

        public SaveMotorbikeRequestBuilder ChangePlateTo(string plate)
        {
            _plate = plate;
            return this;
        }

        public SaveMotorbikeRequest Build()
        {
            return new SaveMotorbikeRequest(_year, _model, _plate);
        }
    }
}
