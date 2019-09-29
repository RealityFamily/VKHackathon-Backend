using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Responses
{
    public class GetRestaurantsInfo
    {
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        public float Rate { get; set; }
    }
}
