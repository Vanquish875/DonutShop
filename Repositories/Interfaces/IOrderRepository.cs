using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrder(int OrderItemID);
        Task<int> CreateOrder(Order order);
        Task<int> UpdateOrder(Order order);
    }
}
