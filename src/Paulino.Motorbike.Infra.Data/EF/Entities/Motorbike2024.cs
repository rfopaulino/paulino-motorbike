using Paulino.Motorbike.Infra.Data.EF.Entities.Base;

namespace Paulino.Motorbike.Infra.Data.EF.Entities
{
    public class Motorbike2024 : Entity
    {
        private Motorbike2024() { }

        public Motorbike2024(string eventMessage)
        {
            EventMessage = eventMessage;
        }

        public string EventMessage { get; set; }
    }
}
