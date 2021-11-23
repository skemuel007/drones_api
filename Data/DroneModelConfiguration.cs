using drones_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Data
{
    public class DroneModelConfiguration : IEntityTypeConfiguration<DroneModel>
    {
        public void Configure(EntityTypeBuilder<DroneModel> builder)
        {
            builder.ToTable("DroneModels");

            builder.HasData(
                new DroneModel
                {
                    DroneModelId = Guid.NewGuid(),
                    ModelName = "Lightweight",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneModel
                {
                    DroneModelId = Guid.NewGuid(),
                    ModelName = "MiddleWeight",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneModel
                {
                    DroneModelId = Guid.NewGuid(),
                    ModelName = "Cruiserweight",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneModel
                {
                    DroneModelId = Guid.NewGuid(),
                    ModelName = "Heavyweight",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
                ) ;
        }
    }
}
