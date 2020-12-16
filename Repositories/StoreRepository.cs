using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using DonutShop.SqlHandler;
using System.Threading.Tasks;

namespace DonutShop.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ISqlDataMapper _db;

        public StoreRepository(ISqlDataMapper db) => _db = db;

        public async Task<int> CreateStore(Store store)
        {
            var sQuery = "INSERT INTO Stores (AddressID, StoreName, TaxRate) VALUES (@AddressID, @StoreName, @TaxRate)";

            return await _db.SaveData(sQuery, new { AddressID = store.AddressID, StoreName = store.StoreName, TaxRate = store.TaxRate });
        }

        public async Task<int> DeleteStore(int storeID)
        {
            var sQuery = "DELETE FROM Stores WHERE StoreID = @ID";

            return await _db.SaveData(sQuery, new { ID = storeID });
        }

        public async Task<Store> GetStore(int storeID)
        {
            var sQuery = "Select * From Stores Where StoreID = @ID";

            return await _db.LoadRecord<Store, dynamic>(sQuery, new { ID = storeID });
        }

        public async Task<int> UpdateStore(Store store)
        {
            var sQuery = "UPDATE Stores AddressID = @AddressID, StoreName = @StoreName, TaxRate = @TaxRate WHERE StoreID = @StoreID";

            return await _db.SaveData(sQuery, new { AddressID = store.AddressID, StoreName = store.StoreName, TaxRate = store.TaxRate, StoreID = store.StoreID });
        }
    }
}
