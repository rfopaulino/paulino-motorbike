using Paulino.Motorbike.Infra.Data.Dapper.Base;

namespace Paulino.Motorbike.Infra.Data.Dapper.Queries
{
    public class GetCNHByNumberDapperQuery(string number) : IDapperQuery
    {
        public string Number { get; } = number;

        public string Query => "select * from cnh where number = @Number";

        public object Params => new { Number };
    }
}
