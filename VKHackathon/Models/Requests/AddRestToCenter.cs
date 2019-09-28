using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
   public class AddRestToCenter
    {
        public Guid ShoppingCenterId { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
