

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public Guid UserId {get; set;}

        public List<ProductDetails> Products { get; set; }

        public string ShippingAddress { get; set; }
        
    }
}