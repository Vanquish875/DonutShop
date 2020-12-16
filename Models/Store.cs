namespace DonutShop.Models
{
    public class Store
    {
        public int StoreID { get; set; }
        public int AddressID { get; set; }
        public string StoreName { get; set; }
        public decimal TaxRate { get; set; }
    }
}
