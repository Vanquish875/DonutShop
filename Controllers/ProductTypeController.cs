using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepo;

        public ProductTypeController(IProductTypeRepository productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
        }

        [HttpGet]
        [Route("api/producttypes")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductType()
        {
            var types = await _productTypeRepo.GetProductTypes();

            if(!types.Any())
            {
                return NotFound();
            }

            return types.ToList();
        }

        [HttpPut]
        [Route("api/producttype/create")]
        public async Task<ActionResult<int>> Create([FromBody] ProductType productType)
        {
            return await _productTypeRepo.CreateProductType(productType);
        }

        [HttpPatch]
        [Route("api/producttype/update")]
        public async Task<ActionResult<int>> Update([FromBody] ProductType productType)
        {
            return await _productTypeRepo.UpdateProductType(productType);
        }

        [HttpDelete]
        [Route("api/producttype/delete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _productTypeRepo.DeleteProductType(id);
        }
    }
}