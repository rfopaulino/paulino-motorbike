using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class RentalFine : Entity
    {
        private RentalFine() { }

        public RentalFine(string description, decimal amount, Rental rental)
        {
            Description = description;
            Amount = amount;
            Rental = rental;
        }

        public string Description { get; set; }
        public decimal Amount { get; set; }

        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
