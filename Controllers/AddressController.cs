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
        [Route("api/address/{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
            var address = await _addressRepo.GetAddress(id);

            if(address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpPost]
        [Route("api/address/create")]
        public async Task<ActionResult<int>> Create([FromBody] Address address)
        {
            return await _addressRepo.CreateAddress(address);
        }

        [HttpPatch]
        [Route("api/address/update")]
        public async Task<ActionResult<int>> Update([FromBody] Address address)
        {
            var resp = await _addressRepo.UpdateAddress(address);

            if(resp == 0)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/address/{id:int}")]
        public async Task<ActionResult<int>> Delete([FromRoute] int id)
        {
            var resp = await _addressRepo.DeleteAddress(id);
            
            if(resp == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}