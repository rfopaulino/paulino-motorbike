using Paulino.Motorbike.Infra.Data.Dapper.Base;

namespace Paulino.Motorbike.Infra.Data.Dapper.Queries
{
    public class GetMotorbikeByPlateDapperQuery(string plate) : IDapperQuery
    {
        public string Plate { get; } = plate;

        public string Query => "select id from public.motorbike where plate = @plate";

        public object Params => new { plate };
    }
}
