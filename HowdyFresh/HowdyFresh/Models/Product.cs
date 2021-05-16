using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyFresh.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, StringLength(100), Display(Name = "Name" )]
        public string Productname { get; set; }

        [Required, StringLength(10000), Display(Name = "Product Description")]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Categories { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
    }
}
