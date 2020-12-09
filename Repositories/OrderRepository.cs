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

        public Task CreateOrder(Order order)
        {
            var sQuery = "INSERT INTO Orders (StoreID, CustomerID, OrderStatusID," +
                    "EmployeeID, OrderDate, TotalPrice) VALUES @store, @customer, @orderStatus," +
                    "@employee, @date, @total";

            return _db.SaveData(sQuery, order);
        }

        public Task UpdateOrder(Order order)
        {
            var sQuery = "UPDATE Orders SET StoreID = @storeID, CustomerID = @customerID, OrderStatusID = @orderStatus," +
                    "EmployeeID = @employee, OrderDate = @date, TotalPrice = @total WHERE OrderID = @ID";

            return _db.SaveData(sQuery, order);
        }
    }
}
