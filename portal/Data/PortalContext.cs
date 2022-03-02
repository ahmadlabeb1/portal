using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using portal.Models;

namespace portal.Data
{
    public class PortalContext : DbContext
    {

        public PortalContext (DbContextOptions<PortalContext> options)
            : base(options)
        {
        }

        public DbSet<portal.Models.Language> Language { get; set; }
        public DbSet<portal.Models.TextResource> textResources { get; set; }
        //public DbSet<portal.Models.IconNav> IconNav { get; set; }
        //public DbSet<NameNav> NameNav { get; set; }
        //public DbSet<subNameNav> SubNameNav { get; set; }
    }
}
