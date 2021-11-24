using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace drones_api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DroneModels",
                columns: table => new
                {
                    DroneModelId = table.Column<Guid>(nullable: false),
                    ModelName = table.Column<string>(maxLength: 90, nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneModels", x => x.DroneModelId);
                });

            migrationBuilder.CreateTable(
                name: "DroneStates",
                columns: table => new
                {
                    DroneStateId = table.Column<Guid>(nullable: false),
                    StateTitle = table.Column<string>(maxLength: 150, nullable: false),
                    Status = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneStates", x => x.DroneStateId);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationId);
                });

            migrationBuilder.CreateTable(
                name: "Drones",
                columns: table => new
                {
                    DroneId = table.Column<Guid>(nullable: false),
                    SerialNumber = table.Column<string>(maxLength: 100, nullable: true),
                    WeightLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatterCapacity = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DroneModelId = table.Column<Guid>(nullable: false),
                    DroneStateId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drones", x => x.DroneId);
                    table.ForeignKey(
                        name: "FK_Drones_DroneModels_DroneModelId",
                        column: x => x.DroneModelId,
                        principalTable: "DroneModels",
                        principalColumn: "DroneModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drones_DroneStates_DroneStateId",
                        column: x => x.DroneStateId,
                        principalTable: "DroneStates",
                        principalColumn: "DroneStateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DroneMedications",
                columns: table => new
                {
                    DroneId = table.Column<Guid>(nullable: false),
                    MedicationId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneMedications", x => new { x.DroneId, x.MedicationId });
                    table.ForeignKey(
                        name: "FK_DroneMedications_Drones_DroneId",
                        column: x => x.DroneId,
                        principalTable: "Drones",
                        principalColumn: "DroneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DroneMedications_Medications_MedicationId",
                        column: x => x.MedicationId,
                        principalTable: "Medications",
                        principalColumn: "MedicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DroneModels",
                columns: new[] { "DroneModelId", "CreatedAt", "ModelName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("68679bc6-04a1-4b83-a477-e13c77da04d7"), new DateTime(2021, 11, 24, 15, 16, 26, 691, DateTimeKind.Local).AddTicks(6679), "Lightweight", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 692, DateTimeKind.Local).AddTicks(7456) },
                    { new Guid("b23f8368-a938-43f2-b803-0306e99927f5"), new DateTime(2021, 11, 24, 15, 16, 26, 692, DateTimeKind.Local).AddTicks(8129), "MiddleWeight", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 692, DateTimeKind.Local).AddTicks(8144) },
                    { new Guid("a353826a-b57f-4675-990f-b76038652cd4"), new DateTime(2021, 11, 24, 15, 16, 26, 692, DateTimeKind.Local).AddTicks(8162), "Cruiserweight", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 692, DateTimeKind.Local).AddTicks(8163) },
                    { new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"), new DateTime(2021, 11, 24, 15, 16, 26, 692, DateTimeKind.Local).AddTicks(8169), "Heavyweight", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 692, DateTimeKind.Local).AddTicks(8170) }
                });

            migrationBuilder.InsertData(
                table: "DroneStates",
                columns: new[] { "DroneStateId", "CreatedAt", "StateTitle", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("90e682ba-1235-4085-8030-95a672d66660"), new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(6807), "IDLE", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7153) },
                    { new Guid("ca9ef137-8da4-4aed-a03b-93b822a072e4"), new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7620), "LOADING", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7634) },
                    { new Guid("d3010830-781c-4a6e-8122-a166d69f530b"), new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7648), "LOADED", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7650) },
                    { new Guid("2837a202-0753-415f-9554-3e86d6f55609"), new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7655), "DELIVERING", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7656) },
                    { new Guid("3304ae56-2bf6-4873-bfe7-74c9c9b20e4c"), new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7659), "DELIVERED", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7660) },
                    { new Guid("b541c479-dcdf-4791-b307-22c4357e33dd"), new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7664), "RETURNING", "Active", new DateTime(2021, 11, 24, 15, 16, 26, 694, DateTimeKind.Local).AddTicks(7665) }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "MedicationId", "Code", "CreatedAt", "Image", "Name", "UpdatedAt", "Weight" },
                values: new object[,]
                {
                    { new Guid("6e1dda1d-ec99-4253-9ddc-79cd8a4505b4"), "74WA3_X6E21", new DateTime(2021, 11, 24, 15, 16, 26, 697, DateTimeKind.Local).AddTicks(1231), "https://res.cloudinary.com/skemuel008/image/upload/v1637753570/Panadol_kkukne.png", "Panadol", new DateTime(2021, 11, 24, 15, 16, 26, 697, DateTimeKind.Local).AddTicks(1544), 250m },
                    { new Guid("853fc8f5-804f-47ad-a0eb-e7769d5874e5"), "TJ2HQ_0NZQS", new DateTime(2021, 11, 24, 15, 16, 26, 697, DateTimeKind.Local).AddTicks(1944), "https://res.cloudinary.com/skemuel008/image/upload/v1637753614/7235_large_EmergenC-SuperOrange-VitaminC-2020_lxws0r.png", "Vitamin C", new DateTime(2021, 11, 24, 15, 16, 26, 697, DateTimeKind.Local).AddTicks(1958), 300m },
                    { new Guid("54c23318-e002-4f14-b978-766d215968e9"), "A20W9_7M2JN", new DateTime(2021, 11, 24, 15, 16, 26, 697, DateTimeKind.Local).AddTicks(1969), "https://res.cloudinary.com/skemuel008/image/upload/v1637753649/BComplex-1024_boxc6g.png", "B Complex", new DateTime(2021, 11, 24, 15, 16, 26, 697, DateTimeKind.Local).AddTicks(1970), 420m },
                    { new Guid("c39227a1-4151-49ca-ad64-e26470b63ced"), "KSU5J_KRYUF", new DateTime(2021, 11, 24, 15, 16, 26, 697, DateTimeKind.Local).AddTicks(1973), "https://res.cloudinary.com/skemuel008/image/upload/v1637753688/tpgbcndploflml9xoqdg_bitlqv.jpg", "Ciprotab", new DateTime(2021, 11, 24, 15, 16, 26, 697, DateTimeKind.Local).AddTicks(1974), 450m }
                });

            migrationBuilder.InsertData(
                table: "Drones",
                columns: new[] { "DroneId", "BatterCapacity", "CreatedAt", "DroneModelId", "DroneStateId", "SerialNumber", "UpdatedAt", "WeightLimit" },
                values: new object[,]
                {
                    { new Guid("1daa4db5-0ce9-4cb3-9388-fd4317cb3904"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(2297), new Guid("68679bc6-04a1-4b83-a477-e13c77da04d7"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "2zr5y-s29xx-oexdl-viuln-5xvr4", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(2608), 200m },
                    { new Guid("8af14faf-d8d9-4ab6-9281-dacb4ae340ef"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3017), new Guid("68679bc6-04a1-4b83-a477-e13c77da04d7"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "2ixei-fnp0e-gmtpa-lxbpl-dz665", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3030), 200m },
                    { new Guid("8f4f64b0-b0e8-4e96-a555-7eac8ba66505"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3047), new Guid("b23f8368-a938-43f2-b803-0306e99927f5"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "8ytyj-ss357-1jtod-12g03-dkz8z", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3048), 300m },
                    { new Guid("91d7c4cd-1b96-4546-abcf-b8e086b26995"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3055), new Guid("b23f8368-a938-43f2-b803-0306e99927f5"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "q8on7-u6wzh-z73fd-t8pkh-p1bqh", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3056), 300m },
                    { new Guid("0c00ee4e-b6f7-4fe7-94ed-ed5abd2a73d3"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3064), new Guid("a353826a-b57f-4675-990f-b76038652cd4"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "o41lm-9nrwp-bhhgk-049u3-3ehjd", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3065), 400m },
                    { new Guid("2035fb8d-f31c-4225-be3a-b250fb704fb9"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3072), new Guid("a353826a-b57f-4675-990f-b76038652cd4"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "u5zoc-escfo-maj11-kqyiw-hyasa", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3073), 400m },
                    { new Guid("a9588e8b-486f-45f1-bb83-d02bee9a2d3b"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3145), new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "ierfv-jrvs0-cmstz-gcwyk-p280m", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3146), 500m },
                    { new Guid("a9715d4a-6ebd-450b-b55b-751a9faadd00"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3154), new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "jjimb-glwfe-qikfw-g10nf-unhqx", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3155), 500m },
                    { new Guid("b5b6a5cd-ebc0-434d-a1a6-38556840948f"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3162), new Guid("b23f8368-a938-43f2-b803-0306e99927f5"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "llccv-1at7t-9mumk-gsq6v-264co", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3163), 500m },
                    { new Guid("cc19ad1e-7fd1-4094-9bef-ee9d7d5d7360"), 100, new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3170), new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"), new Guid("90e682ba-1235-4085-8030-95a672d66660"), "o34br-ey9w0-djcyu-vtxni-n8qgr", new DateTime(2021, 11, 24, 15, 16, 26, 696, DateTimeKind.Local).AddTicks(3171), 500m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DroneMedications_MedicationId",
                table: "DroneMedications",
                column: "MedicationId");

            migrationBuilder.CreateIndex(
                name: "IX_DroneModels_ModelName",
                table: "DroneModels",
                column: "ModelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drones_DroneModelId",
                table: "Drones",
                column: "DroneModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Drones_DroneStateId",
                table: "Drones",
                column: "DroneStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Drones_SerialNumber",
                table: "Drones",
                column: "SerialNumber",
                unique: true,
                filter: "[SerialNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DroneStates_StateTitle",
                table: "DroneStates",
                column: "StateTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medications_Code",
                table: "Medications",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DroneMedications");

            migrationBuilder.DropTable(
                name: "Drones");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "DroneModels");

            migrationBuilder.DropTable(
                name: "DroneStates");
        }
    }
}
