using System;
using System.Collections.Generic;
using System.Linq;

namespace DonutShop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int StoreID { get; set; }
        public int CustomerID { get; set; }
        public int OrderStatusID { get; set; } = 501;
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        //public Address ? DeliveryAddress { get; set; } = new Address();
        public decimal TotalPrice { get; set; } = 0;

        public List<OrderItemClient> OrderItems { get; set; }

        public decimal GetTotalPrice() => OrderItems.Sum(o => o.Product.Price);

        public string GetFormatedTotalPrice() => GetTotalPrice().ToString("0.00");
    }
}
