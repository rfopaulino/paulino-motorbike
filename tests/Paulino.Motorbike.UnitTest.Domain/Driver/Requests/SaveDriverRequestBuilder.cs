using Paulino.Motorbike.Domain.Driver.Requests;

namespace Paulino.Motorbike.UnitTest.Domain.Driver.Requests
{
    public class SaveDriverRequestBuilder
    {
        private string _name = "Rafael Paulino";
        private string _cnpj = "17.332.947/0001-00";
        private DateTime _birthdate = new DateTime(1995, 8, 5);
        private string _cnh = "42697724491";
        private int _cnhTypeId = 1;

        public SaveDriverRequestBuilder ChangeNameTo(string name)
        {
            _name = name;
            return this;
        }

        public SaveDriverRequestBuilder ChangeCNPJTo(string cnpj)
        {
            _cnpj = cnpj;
            return this;
        }

        public SaveDriverRequestBuilder ChangeCNHTo(string cnh)
        {
            _cnh = cnh;
            return this;
        }

        public SaveDriverRequestBuilder ChangeCNHTypeId(int cnhTypeId)
        {
            _cnhTypeId = cnhTypeId;
            return this;
        }

        public SaveDriverRequest Build()
        {
            return new SaveDriverRequest(_name, _cnpj, _birthdate, _cnh, _cnhTypeId);
        }
    }
}
