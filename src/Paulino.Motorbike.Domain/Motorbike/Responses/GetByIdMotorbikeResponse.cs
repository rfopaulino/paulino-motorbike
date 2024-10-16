namespace Paulino.Motorbike.Domain.Motorbike.Responses
{
    public class GetByIdMotorbikeResponse
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
