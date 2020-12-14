using System;
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

        public OrderController(IOrderRepository orderRepo) => _orderRepo = orderRepo;

        [HttpGet]
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
        public async Task<ActionResult<int>> Create(Order order)
        {
            order.OrderDate = DateTime.Now;
            return await _orderRepo.CreateOrder(order);
        }

        [HttpPatch]
        public async Task<ActionResult<int>> Update(Order order)
        {
            return await _orderRepo.UpdateOrder(order);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _orderRepo.DeleteOrder(id);
        }
    }
}