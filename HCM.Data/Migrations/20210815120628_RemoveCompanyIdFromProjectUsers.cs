using Microsoft.EntityFrameworkCore.Migrations;

namespace HCM.Data.Migrations
{
    public partial class RemoveCompanyIdFromProjectUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectUsers_Companies_CompanyId",
                table: "ProjectUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectUsers_CompanyId",
                table: "ProjectUsers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ProjectUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "ProjectUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsers_CompanyId",
                table: "ProjectUsers",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectUsers_Companies_CompanyId",
                table: "ProjectUsers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
