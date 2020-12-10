using Dapper;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using DonutShop.SqlHandler;
using System.Threading.Tasks;

namespace DonutShop.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISqlDataMapper _db;

        public EmployeeRepository(ISqlDataMapper db) => _db = db; 

        public async Task<int> GetAddressID(int employeeID)
        {
            var sQuery = "SELECT AddressID FROM Customers WHERE CustomerID = @ID";

            return await _db.LoadRecord<int, dynamic>(sQuery, new { ID = employeeID });
        }

        public async Task<Employee> GetEmployee(int employeeID)
        {
            //I should also call AddressRepository to bring back address info.
            var AddressID = GetAddressID(employeeID);

            var sQuery = "SELECT * FROM Employees WHERE EmployeeID = @ID";

            return await _db.LoadRecord<Employee, dynamic>(sQuery, new { ID = employeeID });
        }

        public Task<int> CreateEmployee(Employee employee)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@AddressID", employee.AddressID);
            queryParameters.Add("@UserID", employee.UserID);
            queryParameters.Add("@FirstName", employee.FirstName);
            queryParameters.Add("@LastName", employee.LastName);
            //queryParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            return _db.ExecuteStoredProc("CreateEmployee", queryParameters);
        }

        public Task<int> UpdateEmployee(Employee employee)
        {
            var sQuery = "UPDATE Employees SET AddressID = @addressID, UserID = @userID, FirstName = @first" +
                    "LastName = @last, ModifiedDate = @date, IsActive = 0 WHERE EmployeeID = @ID";

            return _db.SaveData(sQuery, employee);
        }

        public Task<int> DeleteEmployee(int employeeID)
        {
            var sQuery = "UPDATE Employees SET IsActive = 0 WHERE EmployeeID = @ID";

            return _db.SaveData(sQuery, new { ID = employeeID });
        }
    }
}
