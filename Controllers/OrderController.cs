using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderItemRepository _orderItemRepo;

        public OrderController(IOrderRepository orderRepo, IOrderItemRepository orderItemRepo)
        {
            _orderRepo = orderRepo;
            _orderItemRepo = orderItemRepo;
        } 

        [HttpGet]
        [Route("api/order/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderRepo.GetOrder(id);

            if(order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        [Route("api/order/create")]
        public async Task<ActionResult<int>> Create([FromBody] Order order)
        {
            var orderid = await _orderRepo.CreateOrder(order);

            foreach (var item in order.OrderItems)
            {
                item.OrderID = orderid;
                await _orderItemRepo.CreateOrderItem(item);
            }

            return orderid;
        }

        [HttpPatch]
        [Route("api/order/update")]
        public async Task<ActionResult<int>> Update([FromBody] Order order)
        {
            return await _orderRepo.UpdateOrder(order);
        }

        [HttpDelete]
        [Route("api/order/delete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _orderRepo.DeleteOrder(id);
        }
    }
}