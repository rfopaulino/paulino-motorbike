using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class CNH : Entity
    {
        private CNH() { }

        public CNH(string number, int cnhTypeId, Document? document)
        {
            Number = number;
            CNHTypeId = cnhTypeId;
            Document = document;
        }

        public string Number { get; set; }

        public int CNHTypeId { get; set; }
        public CNHType CNHType { get; set; }

        public int? DocumentId { get; set; }
        public Document? Document { get; set; }
    }
}
