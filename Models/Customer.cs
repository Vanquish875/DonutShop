﻿using System;
using System.Collections.Generic;

namespace DonutShop.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int AddressID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public ICollection<Order> ? Orders { get; set; }
    }
}
