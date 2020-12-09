using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<Store> GetStore(int storeID);
        Task<int> CreateStore(Store store);
        Task<int> UpdateStore(Store store);
        Task<int> DeleteStore(int storeID);
    }
}
