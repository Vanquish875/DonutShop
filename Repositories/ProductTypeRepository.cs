using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using DonutShop.SqlHandler;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DonutShop.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ISqlDataMapper _db;

        public ProductTypeRepository(ISqlDataMapper db) => _db = db;

        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            var sQuery = "SELECT * FROM ProductType";

            return await _db.LoadData<ProductType, dynamic>(sQuery, new { });
        }

        public async Task<ProductType> GetProductType(int id)
        {
            var sQuery = "Select * From ProductType Where ProductTypeID = @ID";

            return await _db.LoadRecord<ProductType, dynamic>(sQuery, new { ID = id });
        }

        public Task<int> UpdateProductType(ProductType productType)
        {
            var sQuery = "UPDATE ProductType SET ProductTypeName = @name WHERE ProductID = @ID";

            return _db.SaveData(sQuery, new { name = productType.ProductTypeName, ID = productType.ProductTypeName });
        }

        public Task<int> DeleteProductType(int productTypeID)
        {
            var sQuery = "DELETE FROM ProductType WHERE ProductTypeID = @ID";

            return _db.SaveData(sQuery, new { ID = productTypeID });
        }

        public Task<int> CreateProductType(ProductType productType)
        {
            var sQuery = "INSERT INTO ProductType (ProductTypeName) VALUES (@name)";

            return _db.SaveData(sQuery, new { name = productType.ProductTypeName });
        }
    }
}
