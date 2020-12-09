using System;
using System.Collections.Generic;

namespace DonutShop.Models
{
    public class ProductType
    {
        public int ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
