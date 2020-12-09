﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DonutShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public int OrderStatusID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public Address DeliveryAddress { get; set; } = new Address();
        public decimal TotalPrice { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public decimal GetTotalPrice() => OrderItems.Sum(o => o.GetTotalPrice());

        public string GetFormatedTotalPrice() => GetTotalPrice().ToString("0.00");
    }
}
