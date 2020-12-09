using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepo;

        public AddressController(IAddressRepository addressRepo)
        {
            _addressRepo = addressRepo;
        }

        [HttpGet]
        [Route("api/Address/{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            return await _addressRepo.GetAddress(id);
        }

        [HttpPut]
        [Route("api/Address/create")]
        public async Task<ActionResult<int>> Create(Address address)
        {
            return await _addressRepo.CreateAddress(address);
        }

        [HttpPatch]
        [Route("api/Address/update")]
        public async Task<ActionResult<int>> Update(Address address)
        {
            return await _addressRepo.UpdateAddress(address);
        }

        //[HttpPatch]
        //[Route("api/Address/delete")]
        //public async Task<ActionResult<int>> Delete(int id)
        //{
        //    return await _addressRepo.DeleteAddress(id);
        //}
    }
}