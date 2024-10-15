using Paulino.Motorbike.Infra.Data.Dapper.Base;

namespace Paulino.Motorbike.Infra.Data.Dapper.Queries
{
    public class GetDriverByCNPJDapperQuery(string cnpj) : IDapperQuery
    {
        public string Cnpj { get; } = cnpj;

        public string Query => "select id from public.driver where cnpj = @cnpj";

        public object Params => new { cnpj };
    }
}
