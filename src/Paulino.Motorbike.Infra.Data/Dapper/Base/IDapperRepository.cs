namespace Paulino.Motorbike.Infra.Data.Dapper.Base
{
    public interface IDapperRepository
    {
        public Task<T> QueryFirstOrDefaultAsync<T>(IDapperQuery query);
        public Task<IEnumerable<T>> QueryAsync<T>(IDapperQuery query);
    }
}
