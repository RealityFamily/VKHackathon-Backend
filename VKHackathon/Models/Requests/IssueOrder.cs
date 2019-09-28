using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Requests
{
    public class IssueOrder
    {
        public Guid OrderId { get; set; }
        public int Code { get; set; }
    }
}
