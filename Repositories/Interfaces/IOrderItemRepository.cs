using DonutShop.Models;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> GetOrderItem(int OrderItemID);
        Task CreateOrderItem(OrderItem orderItem);
        Task UpdateOrderItem(OrderItem orderItem);
    }
}
