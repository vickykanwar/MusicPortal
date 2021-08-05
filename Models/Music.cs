using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPortal.Models
{
    public class Music
    {
        public int id { get; set; }

        [Display(Name = "Title")]
        public string Mtitle { get; set; }

        [Display(Name = "Singer Name")]
        public string MName { get; set; }

        [Display(Name = "Release Date")]
        public DateTime Mdate { get; set; }

        [Display(Name = "Music")]
        public string MLink { get; set; }

        public Singer singer { get; set; }



    }
}
