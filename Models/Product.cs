using System;
using System.Text.Json;

namespace DonutShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int ProductTypeID { get; set; }
        public string ProductName { get; set; }
        public string ? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ProductSize { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public string GetFormattedPrice() => Price.ToString("0.00");

        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
