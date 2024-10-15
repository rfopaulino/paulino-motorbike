using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class Driver : Entity
    {
        private Driver() { }

        public Driver(string name, string cnpj, DateTime birthdate, CNH cnh)
        {
            Name = name;
            CNPJ = cnpj;
            Birthdate = birthdate;
            CNH = cnh;
        }

        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime Birthdate { get; set; }

        public int CNHId { get; set; }
        public CNH CNH { get; set; }
    }
}
