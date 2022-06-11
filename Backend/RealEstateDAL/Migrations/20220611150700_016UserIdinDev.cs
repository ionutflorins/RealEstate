using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateDAL.Migrations
{
    public partial class _016UserIdinDev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Developers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_AspNetUsers_AppUserId",
                table: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Developers_AppUserId",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Developers");
        }
    }
}
