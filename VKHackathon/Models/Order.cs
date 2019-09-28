using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid ClientId { get; set; }
        public Guid RestaurantId { get; set; }
        public float Price { get; set; }
        public DateTime Time { get; set; }
        public Client Client { get; set; }
        public Restaurant Restaurant { get; set; }
        [NotMapped]
        public IEnumerable MenuItems { get; set; }
        public OrderStatus Status { get; set; }
    }
}
