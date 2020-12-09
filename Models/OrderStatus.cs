using System;
using System.Collections.Generic;

namespace DonutShop.Models
{
    public class OrderStatus
    {
        public int OrderStatusID { get; set; }
        public string OrderStatusName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
