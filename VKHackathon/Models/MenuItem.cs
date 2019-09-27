using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class MenuItem
    {
        public Guid MenuItemId { get; set; }
        public string ItemName { get; set; }
        public float Price { get; set; }
        public string Describe { get; set; }
        public byte[] Image { get; set; }
        public FoodMenu FoodMenu { get; set; }
    }
}
