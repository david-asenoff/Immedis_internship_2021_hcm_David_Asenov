using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HCM.Data.Migrations
{
    public partial class ConvertWorkHoursToInteger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Final work hours from time to int
            migrationBuilder.DropColumn(
                name: "FinalWorkHours",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "FinalWorkHours",
                table: "Projects",
                type: "int");

            // Estimated work hours from time to int
            migrationBuilder.DropColumn(
                name: "EstimatedWorkHours",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "EstimatedWorkHours",
                table: "Projects",
                type: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Final work hours from int to time
            migrationBuilder.DropColumn(
                name: "FinalWorkHours",
                table: "Projects");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "FinalWorkHours",
                table: "Projects",
                type: "time");

            // Estimated work hours from int to time
            migrationBuilder.DropColumn(
                name: "EstimatedWorkHours",
                table: "Projects");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EstimatedWorkHours",
                table: "Projects",
                type: "time");
        }
    }
}
