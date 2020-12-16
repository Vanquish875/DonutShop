using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepo;

        public StoreController(IStoreRepository storeRepo)
        {
            _storeRepo = storeRepo;
        }

        [HttpGet]
        [Route("api/store/{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            var store = await _storeRepo.GetStore(id);

            if(store == null)
            {
                return NotFound();
            }

            return store;
        }

        [HttpPost]
        [Route("api/store/create")]
        public async Task<ActionResult<int>> CreateStore([FromBody] Store store)
        {
            return await _storeRepo.CreateStore(store);
        }

        [HttpPatch]
        [Route("api/store/update")]
        public async Task<ActionResult<int>> UpdateStore([FromBody] Store store)
        {
            return await _storeRepo.UpdateStore(store);
        }

        [HttpDelete]
        [Route("api/store/{id:int}")]
        public async Task<ActionResult<int>> DeleteStore([FromRoute] int id)
        {
            return await _storeRepo.DeleteStore(id);
        }
    }
}