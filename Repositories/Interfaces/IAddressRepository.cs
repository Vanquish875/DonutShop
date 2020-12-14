using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> GetAddress(int addressID);
        Task<int> CreateAddress(Address address);
        Task<int> UpdateAddress(Address address);
        Task<int> DeleteAddress(int addressId);
    }
}
