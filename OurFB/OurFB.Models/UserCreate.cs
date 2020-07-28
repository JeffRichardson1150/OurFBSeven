using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OurFB.Models
{
    public class UserCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public  string Email { get; set; }
    }
}
