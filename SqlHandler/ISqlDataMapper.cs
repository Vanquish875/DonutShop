using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DonutShop.SqlHandler
{
    public interface ISqlDataMapper
    {
        IDbConnection Connection { get; }

        Task<int> ExecuteStoredProc<T>(string sql, T parameters);
        Task<IList<T>> LoadData<T, U>(string sql, U parameters);
        Task<T> LoadRecord<T, U>(string sql, U parameters);
        Task<int> SaveData<T>(string sql, T parameters);
    }
}