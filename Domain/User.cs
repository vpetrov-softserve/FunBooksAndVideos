using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Order> Orders { get; set; }
    }
}