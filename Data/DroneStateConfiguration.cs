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
                    DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                    StateTitle = "IDLE".ToUpper(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState {
                    DroneStateId = new Guid("ca9ef137-8da4-4aed-a03b-93b822a072e4"),
                    StateTitle = "LOADING".ToUpper(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState
                {
                    DroneStateId = new Guid("d3010830-781c-4a6e-8122-a166d69f530b"),
                    StateTitle = "LOADED".ToUpper(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState
                {
                    DroneStateId = new Guid("2837a202-0753-415f-9554-3e86d6f55609"),
                    StateTitle = "DELIVERING".ToUpper(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState
                {
                    DroneStateId = new Guid("3304ae56-2bf6-4873-bfe7-74c9c9b20e4c"),
                    StateTitle = "DELIVERED".ToUpper(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneState
                {
                    DroneStateId = new Guid("b541c479-dcdf-4791-b307-22c4357e33dd"),
                    StateTitle = "RETURNING".ToUpper(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
                );

        }
    }
}
