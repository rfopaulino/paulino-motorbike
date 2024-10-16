using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class RentalPayment : Entity
    {
        public decimal Amount { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public int RentalId { get; set; }
        public Rental Rental { get; set; }
    }
}
