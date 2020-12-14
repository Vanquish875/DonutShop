using System.Collections.Generic;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepo;

        public OrderItemController(IOrderItemRepository orderItemRepo)
        {
            _orderItemRepo = orderItemRepo;
        }

        [HttpPut]
        public async Task<ActionResult<int>> Create(OrderItem orderItem)
        {
            return await _orderItemRepo.CreateOrderItem(orderItem);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderItem>> GetOrderItems(int OrderID)
        {
            return await _orderItemRepo.GetOrderItems(OrderID);
        }

        [HttpPatch]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _orderItemRepo.DeleteOrderItem(id);
        }
    }
}