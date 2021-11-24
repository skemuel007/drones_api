using drones_api.Helpers;
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
                    DroneModelId = new Guid("68679bc6-04a1-4b83-a477-e13c77da04d7"),
                    ModelName = "Lightweight".FirstLetterToCaps(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneModel
                {
                    DroneModelId = new Guid("b23f8368-a938-43f2-b803-0306e99927f5"),
                    ModelName = "MiddleWeight".FirstLetterToCaps(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneModel
                {
                    DroneModelId = new Guid("a353826a-b57f-4675-990f-b76038652cd4"),
                    ModelName = "Cruiserweight".FirstLetterToCaps(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new DroneModel
                {
                    DroneModelId = new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"),
                    ModelName = "Heavyweight".FirstLetterToCaps(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
                ) ;
        }
    }
}
