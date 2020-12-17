using Dapper;
using DonutShop.Models;
using DonutShop.Repositories.Interfaces;
using System.Threading.Tasks;
using DonutShop.SqlHandler;
using System.Data;

namespace DonutShop.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ISqlDataMapper _db;

        public AddressRepository(ISqlDataMapper db) => _db = db;

        public async Task<Address> GetAddress(int addressID)
        {
            var sQuery = "SELECT * FROM Addresss WHERE AddressID = @ID";

            return await _db.LoadRecord<Address, dynamic>(sQuery, new { ID = addressID });
        }

        public async Task<int> CreateAddress(Address address)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@StateCode", address.StateCode);
            queryParameters.Add("@Address1", address.Address1);
            queryParameters.Add("@Address2", address.Address2);
            queryParameters.Add("@PhoneNum", address.PhoneNumber.Replace("-", ""));
            queryParameters.Add("@EmailAddress", address.EmailAddress);
            queryParameters.Add("@City", address.City);
            queryParameters.Add("@ZipCode", address.ZipCode);
            queryParameters.Add("@AddressID", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            await _db.ExecuteStoredProc("CreateAddress", queryParameters);

            return queryParameters.Get<int>("@AddressID");
        }

        public Task<int> UpdateAddress(Address address)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@AddressID", address.AddressID);
            queryParameters.Add("@StateCode", address.StateCode);
            queryParameters.Add("@Address1", address.Address1);
            queryParameters.Add("@Address2", address.Address2);
            queryParameters.Add("@PhoneNum", address.PhoneNumber.Replace("-", ""));
            queryParameters.Add("@EmailAddress", address.EmailAddress);
            queryParameters.Add("@City", address.City);
            queryParameters.Add("@ZipCode", address.ZipCode);
            queryParameters.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

            var result = _db.ExecuteStoredProc("UpdateAddress", queryParameters);
            return result;
        }

        public Task<int> DeleteAddress(int addressId)
        {
            var sQuery = "Delete From Addresss Where AddressID = @ID";

            return _db.SaveData(sQuery, new { ID = addressId });
        }
    }
}
