using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFB.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
        
        [Required]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User Author { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public int PostId { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post CommentPost { get; set; }
        public Guid OwnerID { get; set; }
    }
}
