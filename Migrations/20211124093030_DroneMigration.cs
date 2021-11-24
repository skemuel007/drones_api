using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace drones_api.Migrations
{
    public partial class DroneMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("51a94f4c-745c-4bf4-bcc7-1a90ac06545b"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("65e92421-95f6-491a-a725-df8add6a089b"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("8ae918f2-8c70-440e-a1fd-f235c0ffedf7"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("9d615c07-8d8f-4701-a1a4-57876cd5ebe7"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("0ff1e5af-c797-4fd6-9bc9-df279ad144f4"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("5dc064cc-1349-446d-95f7-6e9b116cd14c"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("63b7ba4b-3cfa-4df2-83cb-877db0824aca"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("6c7d7f60-3f2f-4ad6-9a3d-c41c34b82e9e"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("7d37b2e2-18db-4c09-96ed-3aebc1a44371"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("ffe405c8-4237-4789-8c38-1e3dd894cc9d"));

            migrationBuilder.CreateTable(
                name: "Drones",
                columns: table => new
                {
                    DroneId = table.Column<Guid>(nullable: false),
                    SerialNumber = table.Column<string>(nullable: true),
                    WeightLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BatterCapacity = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drones", x => x.DroneId);
                });

            migrationBuilder.CreateTable(
                name: "Medication",
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
                    table.PrimaryKey("PK_Medication", x => x.MedicationId);
                });

            migrationBuilder.InsertData(
                table: "DroneModels",
                columns: new[] { "DroneModelId", "CreatedAt", "ModelName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8af14faf-d8d9-4ab6-9281-dacb4ae340ef"), new DateTime(2021, 11, 24, 10, 30, 30, 73, DateTimeKind.Local).AddTicks(2259), "Lightweight", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 73, DateTimeKind.Local).AddTicks(9610) },
                    { new Guid("91d7c4cd-1b96-4546-abcf-b8e086b26995"), new DateTime(2021, 11, 24, 10, 30, 30, 74, DateTimeKind.Local).AddTicks(109), "MiddleWeight", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 74, DateTimeKind.Local).AddTicks(119) },
                    { new Guid("8f4f64b0-b0e8-4e96-a555-7eac8ba66505"), new DateTime(2021, 11, 24, 10, 30, 30, 74, DateTimeKind.Local).AddTicks(127), "Cruiserweight", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 74, DateTimeKind.Local).AddTicks(128) },
                    { new Guid("1daa4db5-0ce9-4cb3-9388-fd4317cb3904"), new DateTime(2021, 11, 24, 10, 30, 30, 74, DateTimeKind.Local).AddTicks(130), "Heavyweight", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 74, DateTimeKind.Local).AddTicks(131) }
                });

            migrationBuilder.InsertData(
                table: "DroneStates",
                columns: new[] { "DroneStateId", "CreatedAt", "StateTitle", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b5b6a5cd-ebc0-434d-a1a6-38556840948f"), new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(3901), "IDLE", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4376) },
                    { new Guid("a9715d4a-6ebd-450b-b55b-751a9faadd00"), new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4727), "LOADING", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4742) },
                    { new Guid("cc19ad1e-7fd1-4094-9bef-ee9d7d5d7360"), new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4753), "LOADED", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4754) },
                    { new Guid("2035fb8d-f31c-4225-be3a-b250fb704fb9"), new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4756), "DELIVERING", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4757) },
                    { new Guid("0c00ee4e-b6f7-4fe7-94ed-ed5abd2a73d3"), new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4758), "DELIVERED", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4759) },
                    { new Guid("a9588e8b-486f-45f1-bb83-d02bee9a2d3b"), new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4761), "RETURNING", "Active", new DateTime(2021, 11, 24, 10, 30, 30, 75, DateTimeKind.Local).AddTicks(4762) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DroneStates_StateTitle",
                table: "DroneStates",
                column: "StateTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drones_SerialNumber",
                table: "Drones",
                column: "SerialNumber",
                unique: true,
                filter: "[SerialNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medication_Code",
                table: "Medication",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drones");

            migrationBuilder.DropTable(
                name: "Medication");

            migrationBuilder.DropIndex(
                name: "IX_DroneStates_StateTitle",
                table: "DroneStates");

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("1daa4db5-0ce9-4cb3-9388-fd4317cb3904"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("8af14faf-d8d9-4ab6-9281-dacb4ae340ef"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("8f4f64b0-b0e8-4e96-a555-7eac8ba66505"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("91d7c4cd-1b96-4546-abcf-b8e086b26995"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("0c00ee4e-b6f7-4fe7-94ed-ed5abd2a73d3"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("2035fb8d-f31c-4225-be3a-b250fb704fb9"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("a9588e8b-486f-45f1-bb83-d02bee9a2d3b"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("a9715d4a-6ebd-450b-b55b-751a9faadd00"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("b5b6a5cd-ebc0-434d-a1a6-38556840948f"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("cc19ad1e-7fd1-4094-9bef-ee9d7d5d7360"));

            migrationBuilder.InsertData(
                table: "DroneModels",
                columns: new[] { "DroneModelId", "CreatedAt", "ModelName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9d615c07-8d8f-4701-a1a4-57876cd5ebe7"), new DateTime(2021, 11, 24, 2, 57, 54, 726, DateTimeKind.Local).AddTicks(9425), "Lightweight", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 727, DateTimeKind.Local).AddTicks(6726) },
                    { new Guid("8ae918f2-8c70-440e-a1fd-f235c0ffedf7"), new DateTime(2021, 11, 24, 2, 57, 54, 727, DateTimeKind.Local).AddTicks(7247), "MiddleWeight", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 727, DateTimeKind.Local).AddTicks(7259) },
                    { new Guid("65e92421-95f6-491a-a725-df8add6a089b"), new DateTime(2021, 11, 24, 2, 57, 54, 727, DateTimeKind.Local).AddTicks(7272), "Cruiserweight", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 727, DateTimeKind.Local).AddTicks(7272) },
                    { new Guid("51a94f4c-745c-4bf4-bcc7-1a90ac06545b"), new DateTime(2021, 11, 24, 2, 57, 54, 727, DateTimeKind.Local).AddTicks(7274), "Heavyweight", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 727, DateTimeKind.Local).AddTicks(7275) }
                });

            migrationBuilder.InsertData(
                table: "DroneStates",
                columns: new[] { "DroneStateId", "CreatedAt", "StateTitle", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("63b7ba4b-3cfa-4df2-83cb-877db0824aca"), new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(1964), "IDLE", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2267) },
                    { new Guid("0ff1e5af-c797-4fd6-9bc9-df279ad144f4"), new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2590), "LOADING", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2607) },
                    { new Guid("ffe405c8-4237-4789-8c38-1e3dd894cc9d"), new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2617), "LOADED", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2618) },
                    { new Guid("5dc064cc-1349-446d-95f7-6e9b116cd14c"), new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2620), "DELIVERING", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2621) },
                    { new Guid("6c7d7f60-3f2f-4ad6-9a3d-c41c34b82e9e"), new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2633), "DELIVERED", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2634) },
                    { new Guid("7d37b2e2-18db-4c09-96ed-3aebc1a44371"), new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2636), "RETURNING", "Active", new DateTime(2021, 11, 24, 2, 57, 54, 729, DateTimeKind.Local).AddTicks(2637) }
                });
        }
    }
}
