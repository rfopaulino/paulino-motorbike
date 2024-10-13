using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class Driver : Entity
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime Birthdate { get; set; }

        public int CNHId { get; set; }
        public CNH CNH { get; set; }
    }
}
