using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace drones_api.Migrations
{
    public partial class ModelLengthAdjustMent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("01147346-ba7f-4031-810b-8bf83c870193"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("1f918515-5c2f-4517-9299-4583849cfc05"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("35352b29-8623-49b2-b9aa-3781bbd7b1ea"));

            migrationBuilder.DeleteData(
                table: "DroneModels",
                keyColumn: "DroneModelId",
                keyValue: new Guid("71f3b997-1321-4baa-8c35-a1194f022916"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("33058348-c7bc-40df-8f09-63b2c79f4635"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("3e4cfe25-0ef5-4b97-8fb8-f520bf0201c7"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("3fb1c619-463b-49f5-8264-5174bfc07dbc"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("9cdf1ad6-5546-4a72-abad-f4edc8f5ba46"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("e2e5f920-c053-4a03-bb1f-97d108ea3897"));

            migrationBuilder.DeleteData(
                table: "DroneStates",
                keyColumn: "DroneStateId",
                keyValue: new Guid("f83ff7d2-049f-4983-b774-da97b2de3bc8"));

            migrationBuilder.AlterColumn<string>(
                name: "ModelName",
                table: "DroneModels",
                maxLength: 90,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

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

            migrationBuilder.CreateIndex(
                name: "IX_DroneModels_ModelName",
                table: "DroneModels",
                column: "ModelName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DroneModels_ModelName",
                table: "DroneModels");

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

            migrationBuilder.AlterColumn<string>(
                name: "ModelName",
                table: "DroneModels",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 90);

            migrationBuilder.InsertData(
                table: "DroneModels",
                columns: new[] { "DroneModelId", "CreatedAt", "ModelName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1f918515-5c2f-4517-9299-4583849cfc05"), new DateTime(2021, 11, 22, 0, 14, 45, 547, DateTimeKind.Local).AddTicks(7041), "Lightweight", new DateTime(2021, 11, 22, 0, 14, 45, 548, DateTimeKind.Local).AddTicks(6682) },
                    { new Guid("35352b29-8623-49b2-b9aa-3781bbd7b1ea"), new DateTime(2021, 11, 22, 0, 14, 45, 548, DateTimeKind.Local).AddTicks(7385), "MiddleWeight", new DateTime(2021, 11, 22, 0, 14, 45, 548, DateTimeKind.Local).AddTicks(7399) },
                    { new Guid("71f3b997-1321-4baa-8c35-a1194f022916"), new DateTime(2021, 11, 22, 0, 14, 45, 548, DateTimeKind.Local).AddTicks(7409), "Cruiserweight", new DateTime(2021, 11, 22, 0, 14, 45, 548, DateTimeKind.Local).AddTicks(7410) },
                    { new Guid("01147346-ba7f-4031-810b-8bf83c870193"), new DateTime(2021, 11, 22, 0, 14, 45, 548, DateTimeKind.Local).AddTicks(7413), "Heavyweight", new DateTime(2021, 11, 22, 0, 14, 45, 548, DateTimeKind.Local).AddTicks(7414) }
                });

            migrationBuilder.InsertData(
                table: "DroneStates",
                columns: new[] { "DroneStateId", "CreatedAt", "StateTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("9cdf1ad6-5546-4a72-abad-f4edc8f5ba46"), new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(5981), "IDLE", new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6361) },
                    { new Guid("3e4cfe25-0ef5-4b97-8fb8-f520bf0201c7"), new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6788), "LOADING", new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6810) },
                    { new Guid("3fb1c619-463b-49f5-8264-5174bfc07dbc"), new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6823), "LOADED", new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6824) },
                    { new Guid("f83ff7d2-049f-4983-b774-da97b2de3bc8"), new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6826), "DELIVERING", new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6828) },
                    { new Guid("33058348-c7bc-40df-8f09-63b2c79f4635"), new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6844), "DELIVERED", new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6845) },
                    { new Guid("e2e5f920-c053-4a03-bb1f-97d108ea3897"), new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6848), "RETURNING", new DateTime(2021, 11, 22, 0, 14, 45, 550, DateTimeKind.Local).AddTicks(6850) }
                });
        }
    }
}
