using Dapper;
using Npgsql;
using System.Data;

namespace Paulino.Motorbike.Infra.Data.Dapper.Base
{
    public class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;

        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(IDapperQuery query)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryFirstOrDefaultAsync<T>(query.Query, query.Params);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(IDapperQuery query)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_connectionString))
            {
                dbConnection.Open();
                return await dbConnection.QueryAsync<T>(query.Query, query.Params);
            }
        }
    }
}
