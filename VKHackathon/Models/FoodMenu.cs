using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class FoodMenu
    {
        public Guid FoodMenuId { get; set; }
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
