using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyFresh.Models
{
    public class ArticleComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }
        public string Comment { get; set; }
        public DateTime? ThisDateTime { get; set; }
        public int ArticleId { get; set; }
        public int? Rating { get; set; }
    }
}
