using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace healthApp.Migrations
{
    public partial class mashudu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "NextReminderDate",
                table: "ContraceptionReminders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "ContraceptionReminders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ContraceptionType",
                table: "ContraceptionReminders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReminderDate",
                table: "ContraceptionReminders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReminderID",
                table: "ContraceptionReminders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ContraceptionReminders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContraceptionGuideRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContraceptionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Effectiveness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContraceptionGuideRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilityTrackerRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CycleLength = table.Column<int>(type: "int", nullable: false),
                    OvulationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FertilityWindowStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FertilityWindowEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilityTrackerRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContraceptionGuideRecords");

            migrationBuilder.DropTable(
                name: "FertilityTrackerRecords");

            migrationBuilder.DropColumn(
                name: "ContraceptionType",
                table: "ContraceptionReminders");

            migrationBuilder.DropColumn(
                name: "ReminderDate",
                table: "ContraceptionReminders");

            migrationBuilder.DropColumn(
                name: "ReminderID",
                table: "ContraceptionReminders");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ContraceptionReminders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NextReminderDate",
                table: "ContraceptionReminders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Method",
                table: "ContraceptionReminders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
