using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace drones_api.Migrations
{
    public partial class DroneStateStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "DroneStates",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "DroneStates");

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
    }
}
