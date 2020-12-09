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
        
        public async Task<int> GetAddressID(int customerID)
        {
            var sQuery = "SELECT AddressID FROM Customers WHERE CustomerID = @ID";

            return await _db.LoadRecord<int, dynamic>(sQuery, new { ID = customerID });
        }

        public async Task<Customer> GetCustomer(int customerID)
        {
            //I should also call AddressRepository to bring back address info.
            //var AddressID = GetAddressID(customerID);
            var sQuery = "SELECT * FROM Customers WHERE CustomerID = @ID";

            return await _db.LoadRecord<Customer, dynamic>(sQuery, new { ID = customerID });
        }

        public Task CreateCustomer(Customer customer)
        {
            //var addressRepo = new AddressRepository();
            //int AddressID = addressRepo.CreateAddress(address).Result;
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@AddressID", customer.AddressID);
            queryParameters.Add("@FirstName", customer.FirstName);
            queryParameters.Add("@LastName", customer.LastName);
            queryParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            return _db.ExecuteStoredProc("CreateCustomer", queryParameters);
        }

        public Task UpdateCustomer(Customer customer)
        {
            //var addressRepo = new AddressRepository();
            //int AddressID = addressRepo.CreateAddress(address).Result;
            var sQuery = "UPDATE Customers SET AddressID = @addressID, UserID = @userID, FirstName = @first" +
                    "LastName = @last, ModifiedDate = @date, IsActive = 0 WHERE CustomerID = @ID";

            return _db.SaveData(sQuery, customer);
        }

        public Task DeleteCustomer(int customerID)
        {
            var sQuery = "UPDATE Customers SET IsActive = 0 WHERE CustomerID = @ID";

            return _db.SaveData(sQuery, new { ID = customerID });
        }
    }
}
