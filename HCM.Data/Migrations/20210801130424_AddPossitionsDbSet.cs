using Microsoft.EntityFrameworkCore.Migrations;

namespace HCM.Data.Migrations
{
    public partial class AddPossitionsDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContracts_Possition_PossitionId",
                table: "EmployeeContracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Possition",
                table: "Possition");

            migrationBuilder.RenameTable(
                name: "Possition",
                newName: "Possitions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Possitions",
                table: "Possitions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContracts_Possitions_PossitionId",
                table: "EmployeeContracts",
                column: "PossitionId",
                principalTable: "Possitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContracts_Possitions_PossitionId",
                table: "EmployeeContracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Possitions",
                table: "Possitions");

            migrationBuilder.RenameTable(
                name: "Possitions",
                newName: "Possition");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Possition",
                table: "Possition",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContracts_Possition_PossitionId",
                table: "EmployeeContracts",
                column: "PossitionId",
                principalTable: "Possition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
