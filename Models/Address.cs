using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DonutShop.Models
{
    public class Address
    {
        public int AddressID { get; set; }

        [Required, MaxLength(2)]
        public string StateCode { get; set; }
        [Required, MaxLength(100)]
        public string Address1 { get; set; }
        [Required, MaxLength(100)]
        public string Address2 { get; set; }
        [Required, MaxLength(15)]
        public string PhoneNumber { get; set; }
        [Required, MaxLength(100)]
        public string EmailAddress { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(20)]
        public string ZipCode { get; set; }

        //public ICollection<Customer> Customers { get; set; }
        //public ICollection<Store> Stores { get; set; }
    }
}
