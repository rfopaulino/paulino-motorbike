using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class Document : Entity
    {
        private Document() { }

        public Document(string image, string metadata, int documentTypeId)
        {
            Image = image;
            Metadata = metadata;
            DocumentTypeId = documentTypeId;
        }

        public string Image { get; set; }
        public string Metadata { get; set; }

        public int DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
    }
}
