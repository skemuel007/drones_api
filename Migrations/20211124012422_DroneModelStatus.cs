using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace drones_api.Migrations
{
    public partial class DroneModelStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("12d55a62-b6f4-4cff-824c-c556154cefed"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("65a9dcb1-f0a6-4550-8d15-8834a20abb09"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("88fe4536-3048-4af6-bbfd-2fd78b944db7"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("9126a1f5-3d39-41bf-bed0-4fb6c4a36111"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("60936034-248e-43a5-ab5b-0ea3f8b0ca6c"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("952119b5-d401-4e76-ac7a-d77573aa4618"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("ad81e5c9-0e01-4e4f-bb70-63accc2e23cb"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("bccb4855-9c1d-4b17-98f0-9f6698a40641"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("bee56edf-5ef5-4ece-892e-c679dfebcbb7"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("d94c7160-1dd0-4dfe-b4e3-384158b4c2e6"));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "DroneModels",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DroneModels",
                columns: new[] { "DroneModelId", "CreatedAt", "ModelName", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("853fc8f5-804f-47ad-a0eb-e7769d5874e5"), new DateTime(2021, 11, 24, 2, 24, 21, 841, DateTimeKind.Local).AddTicks(7967), "Lightweight", "Active", new DateTime(2021, 11, 24, 2, 24, 21, 842, DateTimeKind.Local).AddTicks(5390) },
                    { new Guid("6e1dda1d-ec99-4253-9ddc-79cd8a4505b4"), new DateTime(2021, 11, 24, 2, 24, 21, 842, DateTimeKind.Local).AddTicks(5911), "MiddleWeight", "Active", new DateTime(2021, 11, 24, 2, 24, 21, 842, DateTimeKind.Local).AddTicks(5922) },
                    { new Guid("54c23318-e002-4f14-b978-766d215968e9"), new DateTime(2021, 11, 24, 2, 24, 21, 842, DateTimeKind.Local).AddTicks(5929), "Cruiserweight", "Active", new DateTime(2021, 11, 24, 2, 24, 21, 842, DateTimeKind.Local).AddTicks(5930) },
                    { new Guid("c39227a1-4151-49ca-ad64-e26470b63ced"), new DateTime(2021, 11, 24, 2, 24, 21, 842, DateTimeKind.Local).AddTicks(5932), "Heavyweight", "Active", new DateTime(2021, 11, 24, 2, 24, 21, 842, DateTimeKind.Local).AddTicks(5933) }
                });

            migrationBuilder.InsertData(
                table: "DroneStates",
                columns: new[] { "DroneStateId", "CreatedAt", "StateTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0d98f1ad-d5be-494a-99f0-f9122a5b1b52"), new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(341), "IDLE", new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(684) },
                    { new Guid("f627e554-5135-4195-883d-5793a6aa08ad"), new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1027), "LOADING", new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1045) },
                    { new Guid("be9328f8-9164-498e-bd00-8641bd9f4010"), new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1053), "LOADED", new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1054) },
                    { new Guid("d5c7e97e-23e7-4dbb-82fd-3168b9bee5ea"), new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1056), "DELIVERING", new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1057) },
                    { new Guid("7e07094c-8b12-44f4-bdb7-8b75a3d83c96"), new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1066), "DELIVERED", new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1067) },
                    { new Guid("282c8168-3068-42a5-8b64-cd8eff569d37"), new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1069), "RETURNING", new DateTime(2021, 11, 24, 2, 24, 21, 844, DateTimeKind.Local).AddTicks(1070) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("54c23318-e002-4f14-b978-766d215968e9"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("6e1dda1d-ec99-4253-9ddc-79cd8a4505b4"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("853fc8f5-804f-47ad-a0eb-e7769d5874e5"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("c39227a1-4151-49ca-ad64-e26470b63ced"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("0d98f1ad-d5be-494a-99f0-f9122a5b1b52"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("282c8168-3068-42a5-8b64-cd8eff569d37"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("7e07094c-8b12-44f4-bdb7-8b75a3d83c96"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("be9328f8-9164-498e-bd00-8641bd9f4010"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("d5c7e97e-23e7-4dbb-82fd-3168b9bee5ea"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("f627e554-5135-4195-883d-5793a6aa08ad"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DroneModels");

            migrationBuilder.InsertData(
                table: "DroneModels",
                columns: new[] { "DroneModelId", "CreatedAt", "ModelName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9126a1f5-3d39-41bf-bed0-4fb6c4a36111"), new DateTime(2021, 11, 24, 1, 17, 46, 791, DateTimeKind.Local).AddTicks(4732), "Lightweight", new DateTime(2021, 11, 24, 1, 17, 46, 792, DateTimeKind.Local).AddTicks(9330) },
                    { new Guid("65a9dcb1-f0a6-4550-8d15-8834a20abb09"), new DateTime(2021, 11, 24, 1, 17, 46, 793, DateTimeKind.Local).AddTicks(791), "MiddleWeight", new DateTime(2021, 11, 24, 1, 17, 46, 793, DateTimeKind.Local).AddTicks(824) },
                    { new Guid("88fe4536-3048-4af6-bbfd-2fd78b944db7"), new DateTime(2021, 11, 24, 1, 17, 46, 793, DateTimeKind.Local).AddTicks(853), "Cruiserweight", new DateTime(2021, 11, 24, 1, 17, 46, 793, DateTimeKind.Local).AddTicks(855) },
                    { new Guid("12d55a62-b6f4-4cff-824c-c556154cefed"), new DateTime(2021, 11, 24, 1, 17, 46, 793, DateTimeKind.Local).AddTicks(864), "Heavyweight", new DateTime(2021, 11, 24, 1, 17, 46, 793, DateTimeKind.Local).AddTicks(866) }
                });

            migrationBuilder.InsertData(
                table: "DroneStates",
                columns: new[] { "DroneStateId", "CreatedAt", "StateTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("ad81e5c9-0e01-4e4f-bb70-63accc2e23cb"), new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(3275), "IDLE", new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(4220) },
                    { new Guid("d94c7160-1dd0-4dfe-b4e3-384158b4c2e6"), new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5039), "LOADING", new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5073) },
                    { new Guid("bccb4855-9c1d-4b17-98f0-9f6698a40641"), new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5098), "LOADED", new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5100) },
                    { new Guid("952119b5-d401-4e76-ac7a-d77573aa4618"), new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5104), "DELIVERING", new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5106) },
                    { new Guid("bee56edf-5ef5-4ece-892e-c679dfebcbb7"), new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5109), "DELIVERED", new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5111) },
                    { new Guid("60936034-248e-43a5-ab5b-0ea3f8b0ca6c"), new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5114), "RETURNING", new DateTime(2021, 11, 24, 1, 17, 46, 796, DateTimeKind.Local).AddTicks(5116) }
                });
        }
    }
}
