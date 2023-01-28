

namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<ProductDetails> Products { get; set; }
    }
}