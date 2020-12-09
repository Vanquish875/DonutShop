using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DonutShop.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int AddressID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
