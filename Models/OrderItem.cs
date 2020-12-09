using System.Collections.Generic;
using System.Linq;

namespace DonutShop.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public List<Product> Products  { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }

        public decimal GetTotalPrice()
        {
            return Products.Sum(p => p.Price);
        }

        public string GetFormattedTotalPrice()
        {
            return GetTotalPrice().ToString("0.00");
        }
    }
}
