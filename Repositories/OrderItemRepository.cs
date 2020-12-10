using Dapper;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using DonutShop.SqlHandler;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DonutShop.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ISqlDataMapper _db;

        public OrderItemRepository(ISqlDataMapper db) => _db = db;

        public Task<int> CreateOrderItem(OrderItem orderItem)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@Product", orderItem.Product.ToString());
            queryParameters.Add("@ProductID", orderItem.ProductID);
            queryParameters.Add("@OrderID", orderItem.OrderID);
            queryParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            return _db.ExecuteStoredProc("AddOrderItems", queryParameters);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItems(int OrderID)
        {
            var sQuery = "SELECT * FROM OrderItems WHERE OrderID = @ID";

            return await _db.LoadData<OrderItem, dynamic>(sQuery, new { ID = OrderID });
        }
    }
}
