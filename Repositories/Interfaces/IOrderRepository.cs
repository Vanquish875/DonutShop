using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> GetOrder(int OrderItemID);
        Task CreateOrder(Order order);
        Task UpdateOrder(Order order);
    }
}
