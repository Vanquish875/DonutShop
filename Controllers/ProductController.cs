using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DonutShop.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        [Route("api/products/type/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByProductType(int id)
        {
            var products = await _productRepo.GetProductByProductType(id);

            if(!products.Any())
            {
                return NotFound();
            }

            return products.ToList();
        }

        [HttpGet]
        [Route("api/products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepo.GetProducts();

            if(!products.Any())
            {
                return NotFound();
            }

            return products.ToList();
        }

        [HttpGet]
        [Route("api/products/{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepo.GetProduct(id);

            if(product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut]
        [Route("api/products/create")]
        public async Task<ActionResult<int>> Create([FromBody] Product product)
        {
            return await _productRepo.CreateProduct(product);

        }

        [HttpPatch]
        [Route("api/products/update")]
        public async Task<ActionResult<int>> Update([FromBody] Product product)
        {
            return await _productRepo.UpdateProduct(product);
        }

        [HttpDelete]
        [Route("api/products/{id:int}")]
        public async Task<ActionResult<int>> Delete([FromRoute] int id)
        {
            var res = await _productRepo.DeleteProduct(id);

            if(res == 0)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}