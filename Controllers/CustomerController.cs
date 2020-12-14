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
        [Route("api/customers/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _customerRepo.GetCustomer(id);

            if(customer == null)
            {
                return NotFound();
            }

            return customer;
            
        }

        [HttpPut]
        [Route("api/customer/create")]
        public async Task<ActionResult<int>> Create(Customer customer)
        {
            return await _customerRepo.CreateCustomer(customer);
        }

        [HttpPatch]
        [Route("api/customer/update")]
        public async Task<ActionResult<int>> Update(Customer customer)
        {
            return await _customerRepo.UpdateCustomer(customer);
        }

        [HttpDelete]
        [Route("api/customer/delete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _customerRepo.DeleteCustomer(id);
        }
    }
}