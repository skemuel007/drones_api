using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using drones_api.Models;

namespace drones_api.Data
{
    public class DronesApiContext : DbContext
    {
        public DronesApiContext (DbContextOptions<DronesApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DroneModelConfiguration());
            modelBuilder.ApplyConfiguration(new DroneStateConfiguration());
        }

        public virtual DbSet<DroneModel> DroneModels { get; set; }
        public virtual DbSet<DroneState> DroneStates { get; set; }
        
    }
}
