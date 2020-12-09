using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(int customerID);
        Task CreateCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(int customerID);
    }
}
