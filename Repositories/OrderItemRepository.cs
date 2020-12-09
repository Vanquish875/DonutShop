using Dapper;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using DonutShop.SqlHandler;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace DonutShop.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ISqlDataMapper _db;

        public OrderItemRepository(ISqlDataMapper db) => _db = db;

        public async Task<OrderItem> GetOrderItem(int OrderItemID)
        {
            var sQuery = "SELECT * FROM OrderItem WHERE OrderItemID = @ID";

            return await _db.LoadRecord<OrderItem, dynamic>(sQuery, new { ID = OrderItemID });
        }

        public Task CreateOrderItem(OrderItem orderItem)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ProductID", orderItem.ProductID);
            queryParameters.Add("@OrderID", orderItem.OrderID);
            queryParameters.Add("@Quantity", orderItem.Quantity);
            queryParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            return _db.ExecuteStoredProc("AddOrderItems", queryParameters);
        }

        public Task UpdateOrderItem(OrderItem orderItem)
        {
            var sQuery = "UPDATE OrderItems SET ProductID = @productID, OrderID = @orderID, Quantity = @quantity" +
                    "WHERE OrderItemID = @ID";

            return _db.SaveData(sQuery, orderItem);
        }
    }
}
