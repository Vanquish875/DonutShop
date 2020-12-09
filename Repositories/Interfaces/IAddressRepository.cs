using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> GetAddress(int addressID);
        Task CreateAddress(Address address);
        Task UpdateAddress(Address address);
    }
}
