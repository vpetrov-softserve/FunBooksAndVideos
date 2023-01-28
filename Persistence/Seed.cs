using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if(context.Products.Any()) return;

            var products = new List<ProductDetails>
            {
                new Product
                {
                    Name = "Comprehensive First Aid Training",
                    SKU = "ABC1234",
                    IsShipped = false,
                    Price = 34.50M,
                    ProductType = ProductType.Video
                 },
                  new Product
                {
                    Name = "The Girld on the train",
                    SKU = "ABC3241",
                    IsShipped = false,
                    Price = 45.90M,
                    ProductType = ProductType.Book
                 },
                   new Product
                {
                    Name = "Mumble Jumble",
                    SKU = "ABC4512",
                    IsShipped = false,
                    Price = 99.90M,
                    ProductType = ProductType.Book
                 },
                 new Membership
                 {
                    Name = "Book Club Membership",
                    SKU = "ABC467812",
                    IsActivated = false,
                    Price = 19.99M
                }
             };

             await context.Products.AddRangeAsync(products);
             await context.SaveChangesAsync();
        }
    }
}