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
        [Route("api/Employee/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            return await _employeeRepo.GetEmployee(id);
        }

        [HttpPut]
        [Route("api/Employee/create")]
        public async Task<ActionResult<int>> Create(Employee employee)
        {
            return await _employeeRepo.CreateEmployee(employee);
        }

        [HttpPatch]
        [Route("api/Employee/update")]
        public async Task<ActionResult<int>> Update(Employee employee)
        {
            return await _employeeRepo.UpdateEmployee(employee);
        }

        //[HttpPatch]
        //[Route("api/Address/delete")]
        //public async Task<ActionResult<int>> Delete(int id)
        //{
        //    return await _addressRepo.DeleteAddress(id);
        //}
    }
}