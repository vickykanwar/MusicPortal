using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPortal.Models
{
    public class Authenticatio
    {
        public int id { get; set; }

        [Display(Name = " Name")]
        public string UName { get; set; }

        [Display(Name = " Password")]
        public string UPassword { get; set; }

    }
}
