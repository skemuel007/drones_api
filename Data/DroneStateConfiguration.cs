using drones_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Data
{
    public class DroneStateConfiguration : IEntityTypeConfiguration<DroneState>
    {
        public void Configure(EntityTypeBuilder<DroneState> builder)
        {
            builder.ToTable("DroneStates");

            builder.HasData(
                new DroneState
                {
                    DroneStateId = Guid.NewGuid(),
                    StateTitle = "IDLE",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState {
                    DroneStateId = Guid.NewGuid(),
                    StateTitle = "LOADING",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState
                {
                    DroneStateId = Guid.NewGuid(),
                    StateTitle = "LOADED",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState
                {
                    DroneStateId = Guid.NewGuid(),
                    StateTitle = "DELIVERING",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState
                {
                    DroneStateId = Guid.NewGuid(),
                    StateTitle = "DELIVERED",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState
                {
                    DroneStateId = Guid.NewGuid(),
                    StateTitle = "RETURNING",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
                );

        }
    }
}
