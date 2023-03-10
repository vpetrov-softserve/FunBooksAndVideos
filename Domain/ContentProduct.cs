using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class ContentProduct : ProductDetails
    {
        public ProductType ProductType { get; set; }
        public int Count { get; set; }
    }

    public enum ProductType
    {
        Book = 1,
        Video = 2
    }
}