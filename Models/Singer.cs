using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPortal.Models
{
    public class Singer
    {
        public int id { get; set; }

        [Display(Name = " Name")]
        public string UName { get; set; }

        [Display(Name = " Contact")]
        public string Contact { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }



    }
}
