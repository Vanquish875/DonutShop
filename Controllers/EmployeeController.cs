using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        [Route("api/employee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeRepo.GetEmployee(id);

            if(employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        [Route("api/employee/create")]
        public async Task<ActionResult<int>> Create([FromBody] Employee employee)
        {
            return await _employeeRepo.CreateEmployee(employee);
        }

        [HttpPatch]
        [Route("api/employee/update")]
        public async Task<ActionResult<int>> Update([FromBody] Employee employee)
        {
            return await _employeeRepo.UpdateEmployee(employee);
        }

        //[HttpDelete]
        //[Route("api/Address/delete")]
        //public async Task<ActionResult<int>> Delete(int id)
        //{
        //    return await _addressRepo.DeleteAddress(id);
        //}
    }
}