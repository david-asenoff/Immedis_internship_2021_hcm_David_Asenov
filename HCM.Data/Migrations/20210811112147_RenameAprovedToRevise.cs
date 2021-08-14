namespace HCM.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RenameAprovedToRevise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestedLeaves_Users_ApproovedByUserId",
                table: "RequestedLeaves");

            migrationBuilder.RenameColumn(
                name: "ApproovedByUserId",
                table: "RequestedLeaves",
                newName: "RevisedByManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestedLeaves_ApproovedByUserId",
                table: "RequestedLeaves",
                newName: "IX_RequestedLeaves_RevisedByManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedLeaves_Users_RevisedByManagerId",
                table: "RequestedLeaves",
                column: "RevisedByManagerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestedLeaves_Users_RevisedByManagerId",
                table: "RequestedLeaves");

            migrationBuilder.RenameColumn(
                name: "RevisedByManagerId",
                table: "RequestedLeaves",
                newName: "ApproovedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestedLeaves_RevisedByManagerId",
                table: "RequestedLeaves",
                newName: "IX_RequestedLeaves_ApproovedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestedLeaves_Users_ApproovedByUserId",
                table: "RequestedLeaves",
                column: "ApproovedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
