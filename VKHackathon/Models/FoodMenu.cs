using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class FoodMenu
    {
        public Guid FoodMenuId { get; set; }
        
        public List<Restaurant> Restaurants { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
