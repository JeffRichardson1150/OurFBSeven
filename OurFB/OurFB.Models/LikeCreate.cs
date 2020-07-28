using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFB.Models
{
    public class LikeCreate
    {
        public bool Likes { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }

    }
}
