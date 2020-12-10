using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetOrderItem(int OrderItemID);
        Task<int> CreateOrderItem(OrderItem orderItem);
        Task<int> UpdateOrderItem(OrderItem orderItem);
    }
}
