namespace Paulino.Motorbike.Domain.Driver.Responses
{
    public class GetByIdDriverResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public DateTime Birthdate { get; set; }
        public string CNHNumber { get; set; }
    }
}
