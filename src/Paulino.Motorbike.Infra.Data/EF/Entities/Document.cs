using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class Document : Entity
    {
        public string Image { get; set; }
        public string Metadata { get; set; }

        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
