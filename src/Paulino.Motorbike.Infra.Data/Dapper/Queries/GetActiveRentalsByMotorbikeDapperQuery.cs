using Paulino.Motorbike.Infra.Data.Dapper.Base;

namespace Paulino.Motorbike.Infra.Data.Dapper.Queries
{
    public class GetActiveRentalsByMotorbikeDapperQuery(int motorbikeId) : IDapperQuery
    {
        public int MotorbikeId { get; } = motorbikeId;

        public string Query => "select id from rental where motorbike_id = @MotorbikeId and is_active = true";

        public object Params => new { MotorbikeId };
    }
}
