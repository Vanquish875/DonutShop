using DonutShop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonutShop.Repositories.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetProductTypes();
        Task<int> CreateProductType(ProductType productType);
        Task<int> UpdateProductType(ProductType productType);
        Task<int> DeleteProductType(int ProductTypeID);
    }
}
