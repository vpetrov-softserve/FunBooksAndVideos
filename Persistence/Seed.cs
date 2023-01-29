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
                new ContentProduct
                {
                    Name = "Comprehensive First Aid Training",
                    SKU = "ABC1234",
                    Price = 34.50M,
                    ProductType = ProductType.Video,
                    Count = 10
                 },
                  new ContentProduct
                {
                    Name = "The Girld on the train",
                    SKU = "ABC3241",
                    Price = 45.90M,
                    ProductType = ProductType.Book,
                    Count = 15
                 },
                   new ContentProduct
                {
                    Name = "Mumble Jumble",
                    SKU = "ABC4512",
                    Price = 99.90M,
                    ProductType = ProductType.Book,
                    Count = 20
                 },
                 new Membership
                 {
                    Name = "Book Club Membership",
                    SKU = "ABC467812",
                    Price = 19.99M,
                    MembershipType = MembershipType.BookClub
                },
                new Membership
                {
                    Name = "Video Club Membership",
                    SKU = "ABC456712",
                    Price = 29.99M,
                    MembershipType = MembershipType.VideoClub
                }
             };

             await context.Products.AddRangeAsync(products);
             await context.SaveChangesAsync();
        }
    }
}