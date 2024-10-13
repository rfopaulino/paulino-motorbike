using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class Rental : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public decimal TotalAmount { get; set; }

        public int MotorbikeId { get; set; }
        public Motorbike Motorbike { get; set; }

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}
