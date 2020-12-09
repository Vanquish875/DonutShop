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
        [Route("api/Products/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByProductType(int id)
        {
            var results = await _productRepo.GetProductByProductType(id);
            return results.ToList();
        }

        [HttpGet]
        [Route("api/Products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var results = await _productRepo.GetProducts();
            return results.ToList();
        }

        [HttpPut]
        [Route("api/Products/create")]
        public async Task<ActionResult<int>> Create(Product product)
        {
            return await _productRepo.CreateProduct(product);
        }

        [HttpPatch]
        [Route("api/Products/update")]
        public async Task<ActionResult<int>> Update(Product product)
        {
            return await _productRepo.UpdateProduct(product);
        }

        [HttpPatch]
        [Route("api/Products/delete")]
        public async Task<ActionResult<int>> Delete(int ID)
        {
            return await _productRepo.DeleteProduct(ID);
        }
    }
}