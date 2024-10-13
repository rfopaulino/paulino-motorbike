using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class CNH : Entity
    {
        public string Number { get; set; }

        public int CNHTypeId { get; set; }
        public CNHType Type { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
