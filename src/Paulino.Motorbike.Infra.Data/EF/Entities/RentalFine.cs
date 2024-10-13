using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class RentalFine : Entity
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
