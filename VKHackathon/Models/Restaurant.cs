using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Restaurant
    {
        public Guid RestaurantId { get; set; }
        
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public FoodMenu Menu { get; set; }
        public ShoppingCenter ShoppingCenter { get; set; }
        public Order Order { get; set; }
        public float Rate { get; set; }
    }
}
