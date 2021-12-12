using drones_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Data
{
    public class DroneConfiguration : IEntityTypeConfiguration<Drone>
    {
        public void Configure(EntityTypeBuilder<Drone> builder)
        {

            builder.ToTable("Drones");

            builder.HasData(
                new Drone
                {
                    DroneId = new Guid("1daa4db5-0ce9-4cb3-9388-fd4317cb3904"),
                    SerialNumber = "2ZR5Y-S29XX-OEXDL-VIULN-5XVR4",
                    BatterCapacity = 100,
                    WeightLimit = 200,
                    DroneModelId = new Guid("68679bc6-04a1-4b83-a477-e13c77da04d7"),
                    DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                 new Drone
                 {
                     DroneId = new Guid("8af14faf-d8d9-4ab6-9281-dacb4ae340ef"),
                     SerialNumber = "2IXEI-FNP0E-GMTPA-LXBPL-DZ665",
                     BatterCapacity = 100,
                     WeightLimit = 200,
                     DroneModelId = new Guid("68679bc6-04a1-4b83-a477-e13c77da04d7"),
                     DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                 // lightweight
                 new Drone
                 {
                     DroneId = new Guid("8f4f64b0-b0e8-4e96-a555-7eac8ba66505"),
                     SerialNumber = "8YTYJ-SS357-1JTOD-12G03-DKZ8Z",
                     BatterCapacity = 100,
                     WeightLimit = 300,
                     DroneModelId = new Guid("b23f8368-a938-43f2-b803-0306e99927f5"),
                     DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                 new Drone
                 {
                     DroneId = new Guid("91d7c4cd-1b96-4546-abcf-b8e086b26995"),
                     SerialNumber = "Q8ON7-U6WZH-Z73FD-T8PKH-P1BQH",
                     BatterCapacity = 100,
                     WeightLimit = 300,
                     DroneModelId = new Guid("b23f8368-a938-43f2-b803-0306e99927f5"),
                     DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                 // middleweight
                 new Drone
                 {
                     DroneId = new Guid("0c00ee4e-b6f7-4fe7-94ed-ed5abd2a73d3"),
                     SerialNumber = "O41LM-9NRWP-BHHGK-049U3-3EHJD",
                     BatterCapacity = 100,
                     WeightLimit = 400,
                     DroneModelId = new Guid("a353826a-b57f-4675-990f-b76038652cd4"),
                     DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                 new Drone
                 {
                     DroneId = new Guid("2035fb8d-f31c-4225-be3a-b250fb704fb9"),
                     SerialNumber = "U5ZOC-ESCFO-MAJ11-KQYIW-HYASA",
                     BatterCapacity = 100,
                     WeightLimit = 400,
                     DroneModelId = new Guid("a353826a-b57f-4675-990f-b76038652cd4"),
                     DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                 //cruiserweight
                 new Drone
                 {
                     DroneId = new Guid("a9588e8b-486f-45f1-bb83-d02bee9a2d3b"),
                     SerialNumber = "IERFV-JRVS0-CMSTZ-GCWYK-P280M",
                     BatterCapacity = 100,
                     WeightLimit = 500,
                     DroneModelId = new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"),
                     DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                 new Drone
                 {
                     DroneId = new Guid("a9715d4a-6ebd-450b-b55b-751a9faadd00"),
                     SerialNumber = "JJIMB-GLWFE-QIKFW-G10NF-UNHQX",
                     BatterCapacity = 100,
                     WeightLimit = 500,
                     DroneModelId = new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"),
                     DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                 // heavyweight
                 new Drone
                 {
                     DroneId = new Guid("b5b6a5cd-ebc0-434d-a1a6-38556840948f"),
                     SerialNumber = "LLCCV-1AT7T-9MUMK-GSQ6V-264CO",
                     BatterCapacity = 100,
                     WeightLimit = 500,
                     DroneModelId = new Guid("b23f8368-a938-43f2-b803-0306e99927f5"),
                     DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 },
                 new Drone
                 {
                     DroneId = new Guid("cc19ad1e-7fd1-4094-9bef-ee9d7d5d7360"),
                     SerialNumber = "O34BR-EY9W0-DJCYU-VTXNI-N8QGR",
                     BatterCapacity = 100,
                     WeightLimit = 500,
                     DroneModelId = new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"),
                     DroneStateId = new Guid("90e682ba-1235-4085-8030-95a672d66660"),
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                 }
                );
        }
    }
}
