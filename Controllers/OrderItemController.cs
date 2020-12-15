using System.Collections.Generic;
using System.Linq;
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
        [Route("api/orderitem/create")]
        public async Task<ActionResult<int>> Create([FromBody] OrderItem orderItem)
        {
            return await _orderItemRepo.CreateOrderItem(orderItem);
        }

        [HttpGet]
        [Route("api/orderitems/")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems(int OrderID)
        {
            var orderItems = await _orderItemRepo.GetOrderItems(OrderID);

            if(!orderItems.Any())
            {
                return NotFound();
            }

            return orderItems.ToList();
        }

        [HttpPatch]
        [Route("api/orderitem/delete/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _orderItemRepo.DeleteOrderItem(id);
        }
    }
}