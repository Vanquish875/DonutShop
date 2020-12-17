using System.Collections.Generic;
using System.Linq;

namespace DonutShop.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public Product Product { get; set; }
        public int ProductID { get; set; }
        public int ? OrderID { get; set; }
    }
}
