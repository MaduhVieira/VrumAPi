using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VrumApi.Models;

    public class VrumApiContext : DbContext
    {
        public VrumApiContext (DbContextOptions<VrumApiContext> options)
            : base(options)
        {
        }

        public DbSet<VrumApi.Models.Carro> Carro { get; set; }
    }
