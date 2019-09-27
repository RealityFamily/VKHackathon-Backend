using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class ShoppingCenter
    {
        public Guid ShoppingCenterId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}
