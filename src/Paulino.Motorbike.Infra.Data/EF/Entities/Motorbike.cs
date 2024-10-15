using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class Motorbike : Entity
    {
        private Motorbike() { }

        public Motorbike(int year, string model, string plate)
        {
            Year = year;
            Model = model;
            Plate = plate;
        }

        public int Year { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
    }
}
