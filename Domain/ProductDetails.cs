namespace Domain
{
    public abstract class ProductDetails
    {
        public int Id { get; set; }

        public string SKU { get; set; }

        public string Name {get; set; }

         public decimal Price { get; set; }
    }
}