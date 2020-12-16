using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<int> CreateStore(Store store);
        Task<int> DeleteStore(int storeID);
        Task<Store> GetStore(int storeID);
        Task<int> UpdateStore(Store store);
    }
}
