using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
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
        [Route("api/Customers/{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return await _customerRepo.GetCustomer(id);
            //return results;
        }

        [HttpPut]
        [Route("api/Customer/create")]
        public async Task<ActionResult<int>> Create(Customer customer)
        {
            return await _customerRepo.CreateCustomer(customer);
        }

        [HttpPatch]
        [Route("api/Customer/update")]
        public async Task<ActionResult<int>> Update(Customer customer)
        {
            return await _customerRepo.UpdateCustomer(customer);
        }

        [HttpPatch]
        [Route("api/Customer/delete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _customerRepo.DeleteCustomer(id);
        }
    }
}