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
        [Route("api/Order/{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            return await _orderRepo.GetOrder(id);
        }

        [HttpPost]
        [Route("api/Order/create")]
        public async Task<ActionResult<int>> Create(Order order)
        {
            order.OrderDate = DateTime.Now;
            return await _orderRepo.CreateOrder(order);
        }

        [HttpPatch]
        [Route("api/Order/update")]
        public async Task<ActionResult<int>> Update(Order order)
        {
            return await _orderRepo.UpdateOrder(order);
        }

        //[HttpPatch]
        //[Route("api/Order/delete")]
        //public async Task<ActionResult<int>> Delete(int id)
        //{
        //    return await _orderRepo.DeleteOrder(id);
        //}
    }
}