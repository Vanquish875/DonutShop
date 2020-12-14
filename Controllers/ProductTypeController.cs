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
        [Route("api/ProductTypes")]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductType()
        {
            var result = await _productTypeRepo.GetProductTypes();
            return result.ToList();
        }

        [HttpPut]
        [Route("api/ProductType/create")]
        public async Task<ActionResult<int>> Create(ProductType productType)
        {
            return await _productTypeRepo.CreateProductType(productType);
        }

        [HttpPatch]
        [Route("api/ProductType/update")]
        public async Task<ActionResult<int>> Update(ProductType productType)
        {
            return await _productTypeRepo.UpdateProductType(productType);
        }

        [HttpDelete]
        [Route("api/ProductType/delete")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            return await _productTypeRepo.DeleteProductType(id);
        }
    }
}