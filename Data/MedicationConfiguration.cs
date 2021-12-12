using drones_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace drones_api.Data
{
    public class MedicationConfiguration : IEntityTypeConfiguration<Medication>
    {
        public void Configure(EntityTypeBuilder<Medication> builder)
        {
            var folderName = Path.Combine("Resources", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            builder.ToTable("Medications");

            builder.HasData(
                new Medication
                {
                    MedicationId = new Guid("6e1dda1d-ec99-4253-9ddc-79cd8a4505b4"),
                    Code = "74WA3_X6E21",
                    Image = System.IO.File.ReadAllBytes(Path.Combine(pathToSave, "Panadol.png")),
                    Name = "Panadol",
                    Weight = 250,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Medication
                {
                    MedicationId = new Guid("853fc8f5-804f-47ad-a0eb-e7769d5874e5"),
                    Code = "TJ2HQ_0NZQS",
                    Image = System.IO.File.ReadAllBytes(Path.Combine(pathToSave, "VitaminC.png")),
                    Name = "Vitamin C",
                    Weight = 300,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Medication
                {
                    MedicationId = new Guid("54c23318-e002-4f14-b978-766d215968e9"),
                    Code = "A20W9_7M2JN",
                    Image = System.IO.File.ReadAllBytes(Path.Combine(pathToSave, "BComplex.png")),
                    Name = "B Complex",
                    Weight = 420,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new Medication
                {
                    MedicationId = new Guid("c39227a1-4151-49ca-ad64-e26470b63ced"),
                    Code = "KSU5J_KRYUF",
                    Image = System.IO.File.ReadAllBytes(Path.Combine(pathToSave, "ciprotab.jpg")),
                    Name = "Ciprotab",
                    Weight = 450,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                }
                );
        }
    }
}
