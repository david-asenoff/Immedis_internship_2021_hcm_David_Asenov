using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HCM.Data.Migrations
{
    public partial class ChangeTotalHoursDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "Trainings");

            migrationBuilder.AddColumn<int>(
                name: "TotalHours",
                table: "Trainings",
                type: "int",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHours",
                table: "Trainings");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalHours",
                table: "Trainings",
                type: "time",
                nullable: false);
        }
    }
}
