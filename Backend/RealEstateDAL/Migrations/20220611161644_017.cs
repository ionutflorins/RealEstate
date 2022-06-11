using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateDAL.Migrations
{
    public partial class _017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserId",
                table: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Developers_AppUserId",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Developers",
                newName: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Developers_AppUserID",
                table: "Developers",
                column: "AppUserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserID",
                table: "Developers",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserID",
                table: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Developers_AppUserID",
                table: "Developers");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Developers",
                newName: "AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Developers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Developers_AppUserId",
                table: "Developers",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserId",
                table: "Developers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
