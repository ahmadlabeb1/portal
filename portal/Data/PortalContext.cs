﻿using System;
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
    }
}
