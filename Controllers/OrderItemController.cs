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

        [HttpGet]
        [Route("api/OrderItem/{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            return await _orderItemRepo.GetOrderItem(id);
        }

        [HttpPut]
        [Route("api/OrderItem/create")]
        public async Task<ActionResult<int>> Create(OrderItem orderItem)
        {
            return await _orderItemRepo.CreateOrderItem(orderItem);
        }

        [HttpPatch]
        [Route("api/OrderItem/update")]
        public async Task<ActionResult<int>> Update(OrderItem orderItem)
        {
            return await _orderItemRepo.UpdateOrderItem(orderItem);
        }

        //[HttpPatch]
        //[Route("api/OrderItem/delete")]
        //public async Task<ActionResult<int>> Delete(int id)
        //{
        //    return await _orderItemRepo.DeleteOrderItem(id);
        //}
    }
}