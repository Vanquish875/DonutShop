using Dapper;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using DonutShop.SqlHandler;
using System.Data;
using System.Threading.Tasks;

namespace DonutShop.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ISqlDataMapper _db;

        public CustomerRepository(ISqlDataMapper db) => _db = db;

        public async Task<Customer> GetCustomer(int customerID)
        {
            var sQuery = "SELECT * FROM Customers WHERE CustomerID = @ID";

            return await _db.LoadRecord<Customer, dynamic>(sQuery, new { ID = customerID });
        }

        public Task<int> CreateCustomer(Customer customer)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@AddressID", customer.AddressID);
            queryParameters.Add("@user", customer.UserID);
            queryParameters.Add("@FirstName", customer.FirstName);
            queryParameters.Add("@LastName", customer.LastName);
            queryParameters.Add("ModifiedDate", customer.ModifiedDate);
            queryParameters.Add("@IsActive", customer.IsActive);

            return _db.ExecuteStoredProc("CreateCustomer", queryParameters);
        }

        public Task<int> UpdateCustomer(Customer customer)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@CustomerID", customer.CustomerID);
            queryParameters.Add("@AddressID", customer.AddressID);
            queryParameters.Add("@user", customer.UserID);
            queryParameters.Add("@FirstName", customer.FirstName);
            queryParameters.Add("@LastName", customer.LastName);
            queryParameters.Add("ModifiedDate", customer.ModifiedDate);
            queryParameters.Add("@IsActive", customer.IsActive);

            return _db.ExecuteStoredProc("UpdateCustomer", queryParameters);
        }

        public Task<int> DeleteCustomer(int customerID)
        {
            var sQuery = "UPDATE Customers SET IsActive = 0 WHERE CustomerID = @ID";

            return _db.SaveData(sQuery, new { ID = customerID });
        }
    }
}
