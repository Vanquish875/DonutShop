namespace DonutShop.Models
{
    public class OrderItem
    {
        public OrderItem(int productid, int orderid)
        {
            ProductID = productid;
            OrderID = orderid;
        }

        public int OrderItemID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
    }
}
