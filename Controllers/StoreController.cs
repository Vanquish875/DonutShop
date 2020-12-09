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
        [Route("api/Store/{id}")]
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            return await _storeRepo.GetStore(id);
        }

        [HttpPut]
        [Route("api/Store/create")]
        public async Task<ActionResult<int>> Create(Store store)
        {
            return await _storeRepo.CreateStore(store);
        }

        [HttpPatch]
        [Route("api/Store/update")]
        public async Task<ActionResult<int>> Update(Store store)
        {
            return await _storeRepo.UpdateStore(store);
        }

        [HttpPatch]
        [Route("api/Store/delete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _storeRepo.DeleteStore(id);
        }
    }
}