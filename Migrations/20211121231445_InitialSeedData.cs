using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace drones_api.Migrations
{
    public partial class InitialSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DroneModels",
                columns: table => new
                {
                    DroneModelId = table.Column<Guid>(nullable: false),
                    ModelName = table.Column<string>(maxLength: 150, nullable: false),
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
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DroneStates", x => x.DroneStateId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DroneModels");

            migrationBuilder.DropTable(
                name: "DroneStates");
        }
    }
}
