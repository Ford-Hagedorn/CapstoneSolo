using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyFresh.Models
{
    public class ShoppingCart
    {
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
        public string Category { get; set; }
    }
}
