using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Errand_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Errand_Api.Schemas
{
    public class RoutingDb : DbContext
    {
        public RoutingDb(DbContextOptions<RoutingDb> options)
            : base (options) {}
        
        public DbSet<DestinationsList> DestinationsList => Set<DestinationsList>();
        public DbSet <Leg> Legs => Set <Leg>();
    }
}