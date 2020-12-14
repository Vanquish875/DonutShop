using Dapper;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using DonutShop.SqlHandler;
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

        public Task<int> CreateOrder(Order order)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@OrderID", order.OrderID);
            queryParameters.Add("@StoreID", order.StoreID);
            queryParameters.Add("@CustomerID", order.CustomerID);
            queryParameters.Add("@OrderStatus", order.OrderStatusID);
            queryParameters.Add("@EmployeeID", order.EmployeeID);
            queryParameters.Add("@Cost", order.GetTotalPrice());

            return _db.ExecuteStoredProc("CreateOrder", order);
        }

        public Task<int> UpdateOrder(Order order)
        {
            var sQuery = "UPDATE Orders SET StoreID = @storeID, CustomerID = @customerID, OrderStatusID = @orderStatus," +
                    "EmployeeID = @employee, OrderDate = @date, TotalPrice = @total WHERE OrderID = @ID";

            return _db.SaveData(sQuery, order);
        }

        public Task<int> DeleteOrder(int orderID)
        {
            var sQuery = "Delete From Order Where OrderID = @ID";

            return _db.SaveData(sQuery, new { ID = orderID });
        }
    }
}
