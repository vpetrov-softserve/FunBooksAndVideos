
namespace Application.DTOs
{
    public class OrderDto
    {
        public Guid UserId { get; set; }
        public List<int> ProductIds { get; set; }

        public string ShippingAddress { get; set; }
    }
}