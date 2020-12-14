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
        public async Task<ActionResult<Store>> GetStore(int id)
        {
            return await _storeRepo.GetStore(id);
        }

        [HttpPut]
        public async Task<ActionResult<int>> Create(Store store)
        {
            return await _storeRepo.CreateStore(store);
        }

        [HttpPatch]
        public async Task<ActionResult<int>> Update(Store store)
        {
            return await _storeRepo.UpdateStore(store);
        }

        [HttpPatch]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _storeRepo.DeleteStore(id);
        }
    }
}