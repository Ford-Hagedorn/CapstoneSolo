using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyFresh.Models
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }
        public string Supplier { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
