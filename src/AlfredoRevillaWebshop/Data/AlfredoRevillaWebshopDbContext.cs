using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlfredoRevillaWebshop.Models;

    public class AlfredoRevillaWebshopDbContext : DbContext
    {
        public AlfredoRevillaWebshopDbContext (DbContextOptions<AlfredoRevillaWebshopDbContext> options)
            : base(options)
        {
        }

        public DbSet<AlfredoRevillaWebshop.Models.Product> Product { get; set; }
    }
