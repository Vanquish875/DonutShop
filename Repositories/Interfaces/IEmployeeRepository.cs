using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(int employeeID);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeID);
    }
}
