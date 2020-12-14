using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerController(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return await _customerRepo.GetCustomer(id);
            //return results;
        }

        [HttpPut]
        public async Task<ActionResult<int>> Create(Customer customer)
        {
            return await _customerRepo.CreateCustomer(customer);
        }

        [HttpPatch]
        public async Task<ActionResult<int>> Update(Customer customer)
        {
            return await _customerRepo.UpdateCustomer(customer);
        }

        [HttpPatch]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _customerRepo.DeleteCustomer(id);
        }
    }
}