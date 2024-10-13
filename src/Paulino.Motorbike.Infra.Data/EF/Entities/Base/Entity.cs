namespace Paulino.Motorbike.Infra.Data.EF.Entities.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
