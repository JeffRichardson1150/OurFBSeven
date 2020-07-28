using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurFB.Data
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
