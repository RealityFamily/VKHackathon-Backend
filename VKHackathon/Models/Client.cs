using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class Client : IdentityUser<Guid>
    {
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<Order> Orders { get; set; }

    }
}
