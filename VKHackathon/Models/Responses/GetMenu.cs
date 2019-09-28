using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Responses
{
    public class GetMenu
    {
        public Guid MenuItemId { get; set; }
        public string ItemName { get; set; }
        public float Price { get; set; }
        public string Describe { get; set; }
        public byte[] Image { get; set; }
    }
}
