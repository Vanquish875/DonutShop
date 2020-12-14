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

        [HttpPut]
        [Route("api/store/create")]
        public async Task<ActionResult<int>> Create(Store store)
        {
            return await _storeRepo.CreateStore(store);
        }

        [HttpPatch]
        [Route("api/store/update")]
        public async Task<ActionResult<int>> Update(Store store)
        {
            return await _storeRepo.UpdateStore(store);
        }

        [HttpPatch]
        [Route("api/store/delete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _storeRepo.DeleteStore(id);
        }
    }
}