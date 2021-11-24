using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace drones_api.Migrations
{
    public partial class DroneForiegnRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Medication",
                table: "Medication");

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

            migrationBuilder.RenameTable(
                name: "Medication",
                newName: "Medications");

            migrationBuilder.RenameIndex(
                name: "IX_Medication_Code",
                table: "Medications",
                newName: "IX_Medications_Code");

            migrationBuilder.AddColumn<Guid>(
                name: "DroneModelId",
                table: "Drones",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DroneStateId",
                table: "Drones",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medications",
                table: "Medications",
                column: "MedicationId");

            migrationBuilder.InsertData(
                table: "DroneModels",
                columns: new[] { "DroneModelId", "CreatedAt", "ModelName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("68679bc6-04a1-4b83-a477-e13c77da04d7"), new DateTime(2021, 11, 24, 10, 56, 46, 267, DateTimeKind.Local).AddTicks(9105), "Lightweight", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 268, DateTimeKind.Local).AddTicks(6138) },
                    { new Guid("b23f8368-a938-43f2-b803-0306e99927f5"), new DateTime(2021, 11, 24, 10, 56, 46, 268, DateTimeKind.Local).AddTicks(6617), "MiddleWeight", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 268, DateTimeKind.Local).AddTicks(6629) },
                    { new Guid("a353826a-b57f-4675-990f-b76038652cd4"), new DateTime(2021, 11, 24, 10, 56, 46, 268, DateTimeKind.Local).AddTicks(6637), "Cruiserweight", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 268, DateTimeKind.Local).AddTicks(6638) },
                    { new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"), new DateTime(2021, 11, 24, 10, 56, 46, 268, DateTimeKind.Local).AddTicks(6640), "Heavyweight", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 268, DateTimeKind.Local).AddTicks(6641) }
                });

            migrationBuilder.InsertData(
                table: "DroneStates",
                columns: new[] { "DroneStateId", "CreatedAt", "StateTitle", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("90e682ba-1235-4085-8030-95a672d66660"), new DateTime(2021, 11, 24, 10, 56, 46, 269, DateTimeKind.Local).AddTicks(9679), "IDLE", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 269, DateTimeKind.Local).AddTicks(9942) },
                    { new Guid("ca9ef137-8da4-4aed-a03b-93b822a072e4"), new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(245), "LOADING", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(260) },
                    { new Guid("d3010830-781c-4a6e-8122-a166d69f530b"), new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(269), "LOADED", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(271) },
                    { new Guid("2837a202-0753-415f-9554-3e86d6f55609"), new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(272), "DELIVERING", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(273) },
                    { new Guid("3304ae56-2bf6-4873-bfe7-74c9c9b20e4c"), new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(275), "DELIVERED", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(276) },
                    { new Guid("b541c479-dcdf-4791-b307-22c4357e33dd"), new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(278), "RETURNING", "Active", new DateTime(2021, 11, 24, 10, 56, 46, 270, DateTimeKind.Local).AddTicks(279) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drones_DroneModelId",
                table: "Drones",
                column: "DroneModelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drones_DroneStateId",
                table: "Drones",
                column: "DroneStateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drones_DroneModels_DroneModelId",
                table: "Drones",
                column: "DroneModelId",
                principalTable: "DroneModels",
                principalColumn: "DroneModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drones_DroneStates_DroneStateId",
                table: "Drones",
                column: "DroneStateId",
                principalTable: "DroneStates",
                principalColumn: "DroneStateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drones_DroneModels_DroneModelId",
                table: "Drones");

            migrationBuilder.DropForeignKey(
                name: "FK_Drones_DroneStates_DroneStateId",
                table: "Drones");

            migrationBuilder.DropIndex(
                name: "IX_Drones_DroneModelId",
                table: "Drones");

            migrationBuilder.DropIndex(
                name: "IX_Drones_DroneStateId",
                table: "Drones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medications",
                table: "Medications");

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("68679bc6-04a1-4b83-a477-e13c77da04d7"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("79fe7bc1-fafb-4e29-8712-d94b79859648"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("a353826a-b57f-4675-990f-b76038652cd4"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("b23f8368-a938-43f2-b803-0306e99927f5"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("2837a202-0753-415f-9554-3e86d6f55609"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("3304ae56-2bf6-4873-bfe7-74c9c9b20e4c"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("90e682ba-1235-4085-8030-95a672d66660"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("b541c479-dcdf-4791-b307-22c4357e33dd"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("ca9ef137-8da4-4aed-a03b-93b822a072e4"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("d3010830-781c-4a6e-8122-a166d69f530b"));

            migrationBuilder.DropColumn(
                name: "DroneModelId",
                table: "Drones");

            migrationBuilder.DropColumn(
                name: "DroneStateId",
                table: "Drones");

            migrationBuilder.RenameTable(
                name: "Medications",
                newName: "Medication");

            migrationBuilder.RenameIndex(
                name: "IX_Medications_Code",
                table: "Medication",
                newName: "IX_Medication_Code");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medication",
                table: "Medication",
                column: "MedicationId");

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
        }
    }
}
