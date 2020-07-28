using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFB.Data
{
    public class Reply : Comment
    {

        [Key]
        public int ReplyId { get; set;  }

        [Required]
        public int CommentId { get; set; }
        [ForeignKey(nameof(CommentId))]
        public virtual Comment ReplyComment { get; set; }
        
    }
}
