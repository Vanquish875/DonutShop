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

            return Ok(customer);
            
        }

        [HttpPost]
        [Route("api/customer/create")]
        public async Task<ActionResult<int>> CreateCustomer(Customer customer)
        {
            return await _customerRepo.CreateCustomer(customer);
        }

        [HttpPatch]
        [Route("api/customer/update")]
        public async Task<ActionResult<int>> UpdateCustomer(Customer customer)
        {
            return await _customerRepo.UpdateCustomer(customer);
        }

        [HttpDelete]
        [Route("api/customer/{id:int}")]
        public async Task<ActionResult<int>> DeleteCustomer(int id)
        {
            return await _customerRepo.DeleteCustomer(id);
        }
    }
}