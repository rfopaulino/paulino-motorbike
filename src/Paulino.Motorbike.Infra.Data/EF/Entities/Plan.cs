using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class Plan : Entity
    {
        public int TermDays { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal AdditionalDaily { get; set; }
        public decimal PercentageFine { get; set; }
        public bool IsActive { get; set; }
    }
}
