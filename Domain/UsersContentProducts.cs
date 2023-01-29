using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class UsersContentProducts
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public ContentProduct ContentProduct { get; set; }
        public bool IsShipped { get; set; }
        public Order Order { get; set; }
    }
}