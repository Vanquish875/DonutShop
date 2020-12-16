using DonutShop.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DonutShop.Models;
using DonutShop.SqlHandler;

namespace DonutShop.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ISqlDataMapper _db;

        public ProductRepository(ISqlDataMapper db) => _db = db;

        public async Task<IEnumerable<Product>> GetProductByProductType(int ProductTypeID)
        {
            var sQuery = "SELECT ProductID, ProductName, ProductDescription, Price, ProductSize" +
                    " FROM Products WHERE ProductTypeID = @ID";

            return await _db.LoadData<Product, dynamic>(sQuery, new { ID = ProductTypeID });
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var sQuery = "SELECT * FROM Products";

            return await _db.LoadData<Product, dynamic>(sQuery, new { });
        }

        public async Task<Product> GetProduct(int ProductID)
        {
            var sQuery = "Select * FROM Products WHERE ProductID = @ID";

            return await _db.LoadRecord<Product, dynamic>(sQuery, new { ID = ProductID });
        }

        public Task<int> UpdateProduct(Product product)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ProductID", product.ProductID);
            queryParameters.Add("@ProductTypeID", product.ProductTypeID);
            queryParameters.Add("@ProductName", product.ProductName);
            queryParameters.Add("@Description", product.ProductDescription);
            queryParameters.Add("@Price", product.Price);
            queryParameters.Add("@ProductSize", product.ProductSize);
            queryParameters.Add("@ModifiedDate", product.ModifiedDate);
            queryParameters.Add("@IsActive", product.IsActive);

            return _db.ExecuteStoredProc("UpdateProduct", queryParameters);
        }

        public Task<int> DeleteProduct(int productID)
        {
            return _db.ExecuteStoredProc("DeleteProduct", new { ID = productID });
        }

        public Task<int> CreateProduct(Product product)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ProductTypeID", product.ProductTypeID);
            queryParameters.Add("@ProductName", product.ProductName);
            queryParameters.Add("@Description", product.ProductDescription);
            queryParameters.Add("@Price", product.Price);
            queryParameters.Add("@ProductSize", product.ProductSize);
            queryParameters.Add("@ModifiedDate", product.ModifiedDate);
            queryParameters.Add("@IsActive", product.IsActive);

            return _db.ExecuteStoredProc("CreateProduct", queryParameters);
        }
    }
}
