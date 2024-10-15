namespace Paulino.Motorbike.Infra.Data.Dapper.Base
{
    public interface IDapperQuery
    {
        public string Query { get; }
        public object Params { get; }
    }
}
