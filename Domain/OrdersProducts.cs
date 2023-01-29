namespace Domain
{
    public class OrdersProducts
    {
        public int OrdersProductsId { get; set; }
        public Order Order { get; set; }
        public ProductDetails Product { get; set; }
    }
}