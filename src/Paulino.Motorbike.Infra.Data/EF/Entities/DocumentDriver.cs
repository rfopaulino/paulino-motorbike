using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class DocumentDriver : Entity
    {
        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
