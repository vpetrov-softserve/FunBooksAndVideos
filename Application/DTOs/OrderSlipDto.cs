using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class OrderSlipDto
    {
        public int OrderId { get; set; }

        public decimal TotalPrice { get; set; }

        public List<ProductDto> Products { get; set; }

        public string ShppingAddress { get; set; }
    }
}