using DonutShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductByProductType(int ProductTypeID);
        Task<IEnumerable<Product>> GetProducts();
        Task<int> CreateProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(int ProductID);
    }
}