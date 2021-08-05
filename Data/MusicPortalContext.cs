using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicPortal.Models;

namespace MusicPortal.Data
{
    public class MusicPortalContext : DbContext
    {
        public MusicPortalContext (DbContextOptions<MusicPortalContext> options)
            : base(options)
        {
        }

        public DbSet<MusicPortal.Models.Authenticatio> Authenticatio { get; set; }

        public DbSet<MusicPortal.Models.Music> Music { get; set; }

        public DbSet<MusicPortal.Models.Singer> Singer { get; set; }

        public DbSet<MusicPortal.Models.Video> Video { get; set; }
    }
}
