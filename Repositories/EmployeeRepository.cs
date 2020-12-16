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

        public async Task<Employee> GetEmployee(int employeeID)
        {
            var sQuery = "SELECT * FROM Employees WHERE EmployeeID = @ID";

            return await _db.LoadRecord<Employee, dynamic>(sQuery, new { ID = employeeID });
        }

        public Task<int> CreateEmployee(Employee employee)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@User", employee.UserID);
            queryParameters.Add("@FirstName", employee.FirstName);
            queryParameters.Add("@LastName", employee.LastName);
            queryParameters.Add("@AddressID", employee.AddressID);
            queryParameters.Add("@ModifiedDate", employee.ModifiedDate);
            queryParameters.Add("@IsActive", employee.IsActive);

            return _db.ExecuteStoredProc("CreateEmployee", queryParameters);
        }

        public Task<int> UpdateEmployee(Employee employee)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@User", employee.UserID);
            queryParameters.Add("@FirstName", employee.FirstName);
            queryParameters.Add("@LastName", employee.LastName);
            queryParameters.Add("@AddressID", employee.AddressID);
            queryParameters.Add("@ModifiedDate", employee.ModifiedDate);
            queryParameters.Add("@IsActive", employee.IsActive);

            return _db.ExecuteStoredProc("UpdateEmployee", queryParameters);
        }

        public Task<int> DeleteEmployee(int employeeID)
        {
            var sQuery = "UPDATE Employees SET IsActive = 0 WHERE EmployeeID = @ID";

            return _db.SaveData(sQuery, new { ID = employeeID });
        }
    }
}
