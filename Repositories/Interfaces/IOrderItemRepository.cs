using DonutShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<int> CreateOrderItem(OrderItem orderItem);
        Task<IEnumerable<OrderItem>> GetOrderItems(int OrderID);
        Task<int> DeleteOrderItem(int OrderID);
    }
}
