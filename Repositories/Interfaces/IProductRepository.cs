using DonutShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductByProductType(int ProductTypeID);
        Task<IEnumerable<Product>> GetProducts();
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int ProductID);
    }
}