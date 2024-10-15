using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class DocumentDriver : Entity
    {
        private DocumentDriver() { }

        public DocumentDriver(Driver driver, Document document)
        {
            Driver = driver;
            Document = document;
        }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
