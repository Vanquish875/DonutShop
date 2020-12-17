using Dapper;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using DonutShop.SqlHandler;
using System.Data;
using System.Threading.Tasks;

namespace DonutShop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ISqlDataMapper _db;

        public OrderRepository(ISqlDataMapper db) => _db = db;

        public async Task<Order> GetOrder(int orderID)
        {
            var sQuery = "SELECT * FROM Order WHERE OrderItemID = @ID";

            return await _db.LoadRecord<Order, dynamic>(sQuery, new { ID = orderID });
        }

        public async Task<int> CreateOrder(Order order)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@StoreID", order.StoreID);
            queryParameters.Add("@CustomerID", order.CustomerID);
            queryParameters.Add("@OrderStatus", order.OrderStatusID);
            queryParameters.Add("@EmployeeID", order.EmployeeID);
            queryParameters.Add("@OrderDate", order.OrderDate);
            queryParameters.Add("@Cost", order.GetTotalPrice());
            queryParameters.Add("@OrderID", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await _db.ExecuteStoredProc("CreateOrder", queryParameters);

            return queryParameters.Get<int>("@OrderID");
        }

        public async Task<int> UpdateOrder(Order order)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OrderID", order.OrderID);
            queryParameters.Add("@StoreID", order.StoreID);
            queryParameters.Add("@CustomerID", order.CustomerID);
            queryParameters.Add("@OrderStatus", order.OrderStatusID);
            queryParameters.Add("@EmployeeID", order.EmployeeID);
            queryParameters.Add("@OrderDate", order.OrderDate);
            queryParameters.Add("@Cost", order.GetTotalPrice());

            return await _db.ExecuteStoredProc("UpdateOrder", queryParameters);
        }

        public async Task<int> DeleteOrder(int orderID)
        {
            var sQuery = "Delete From Order Where OrderID = @ID";

            return await _db.SaveData(sQuery, new { ID = orderID });
        }
    }
}
