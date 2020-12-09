using DonutShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetProductTypes();
        Task CreateProductType(ProductType productType);
        Task UpdateProductType(ProductType productType);
        Task DeleteProductType(int ProductTypeID);
    }
}
