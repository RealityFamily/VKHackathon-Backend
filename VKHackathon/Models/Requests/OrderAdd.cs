using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
    public class OrderAdd
    {
        public Guid ClientId { get; set; }
        public Guid RestaurantId { get; set; }
        public float Price { get; set; }
        public List<Guid> Items { get; set; }
        
    }
}
