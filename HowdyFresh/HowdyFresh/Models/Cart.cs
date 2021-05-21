using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyFresh.Models
{
    public class Cart
    {
        public string ItemId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public string ItemName { get; set; }

    }
}
