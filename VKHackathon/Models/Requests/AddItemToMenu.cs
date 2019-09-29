using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
    public class AddItemToMenu
    {

        public string ItemName { get; set; }
        public float Price { get; set; }
        public string Describe { get; set; }
        public Guid MenuId { get; set; }
    }
}
