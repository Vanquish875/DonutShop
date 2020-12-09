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
            var sQuery = "SELECT * FROM ProductTypes";

            return await _db.LoadData<ProductType, dynamic>(sQuery, new { });
        }

        public Task UpdateProductType(ProductType productType)
        {
            var sQuery = "UPDATE ProductType SET ProductTypeName = @name WHERE ProductID = @ID";

            return _db.SaveData(sQuery, productType);
        }

        public Task DeleteProductType(int productTypeID)
        {
            var sQuery = "DELETE FROM ProductType WHERE ProductTypeID = @ID";

            return _db.SaveData(sQuery, new { ID = productTypeID });
        }

        public Task CreateProductType(ProductType productType)
        {
            var sQuery = "INSERT INTO ProductType (ProductTypeName) VALUES @name";

            return _db.SaveData(sQuery, productType);
        }
    }
}
