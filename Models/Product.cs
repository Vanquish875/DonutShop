using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DonutShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ProductSize { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public string GetFormattedPrice() => Price.ToString("0.00");

        //public ICollection<OrderItem> OrderItems { get; set; }

        //public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
