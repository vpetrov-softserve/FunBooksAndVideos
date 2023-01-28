using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Product : ProductDetails
    {
        public ProductType ProductType { get; set; }

        public bool IsShipped { get; set; }
    }

    public enum ProductType
    {
        Book = 1,
        Video = 2
    }
}