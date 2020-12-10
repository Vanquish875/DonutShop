using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.SqlHandler
{
    public class SqlDataMapper : ISqlDataMapper
    {
        private readonly IConfiguration _config;

        public SqlDataMapper(IConfiguration config) => _config = config;

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public async Task<IList<T>> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = Connection)
            {
                var data = await conn.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }

        public async Task<int> SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection conn = Connection)
            {
                var data = await conn.ExecuteAsync(sql, parameters);
                return data; 
            }
        }

        public async Task<T> LoadRecord<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = Connection)
            {
                var data = await conn.QueryAsync<T>(sql, parameters);
                return data.FirstOrDefault();
            }
        }

        public async Task<int> ExecuteStoredProc<T>(string sql, T parameters)
        {
            using (IDbConnection conn = Connection)
            {
                var data = await conn.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
    }
}
