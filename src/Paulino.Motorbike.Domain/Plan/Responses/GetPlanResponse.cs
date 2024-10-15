namespace Paulino.Motorbike.Domain.Plan.Responses
{
    public class GetPlanResponse
    {
        public int Id { get; set; }
        public int TermDays { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal AdditionalDaily { get; set; }
        public decimal PercentageFine { get; set; }
        public bool IsActive { get; set; }
    }
}
