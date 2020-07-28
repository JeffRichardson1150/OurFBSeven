using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFB.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }

        //[Required]
        //public int UserId { get; set; }
        //[ForeignKey(nameof(UserId))]

        //public virtual User Author { get; set; }
        




    }
}
