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

            // make model name unique
            modelBuilder.Entity<DroneModel>()
                .HasIndex(d => d.ModelName)
                .IsUnique();

            modelBuilder.Entity<Medication>()
                .HasIndex(m => m.Code)
                .IsUnique();

            modelBuilder.Entity<Drone>()
                .HasIndex(d => d.SerialNumber)
                .IsUnique();

            modelBuilder.Entity<DroneState>()
                .HasIndex(d => d.StateTitle)
                .IsUnique();

            // modelBuilder.Entity<Drone>().Property(d => d.WeightLimit).HasColumnType("decimal(18,2)");
        }

        public virtual DbSet<DroneModel> DroneModels { get; set; }
        public virtual DbSet<DroneState> DroneStates { get; set; }
        public virtual DbSet<Drone> Drones { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        
    }
}
