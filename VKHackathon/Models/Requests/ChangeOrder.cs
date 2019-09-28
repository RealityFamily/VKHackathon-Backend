using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
    public class ChangeOrder
    {
        public Guid OrderId { get; set; }
        public List<Guid> Items { get; set; }
    }
}
