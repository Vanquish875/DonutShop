using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using DonutShop.SqlHandler;
using System;
using System.Threading.Tasks;

namespace DonutShop.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ISqlDataMapper _db;

        public StoreRepository(ISqlDataMapper db) => _db = db;

        public Task<int> CreateStore(Store store)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteStore(int storeID)
        {
            throw new NotImplementedException();
        }

        public Task<Store> GetStore(int storeID)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateStore(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
