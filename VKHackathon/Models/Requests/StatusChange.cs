using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
    public class StatusChange
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
    }
}
