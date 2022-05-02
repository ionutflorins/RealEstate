using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateDAL.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Developers_DeveloperID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_DeveloperID",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DeveloperID",
                table: "Projects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeveloperID",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DeveloperID",
                table: "Projects",
                column: "DeveloperID");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Developers_DeveloperID",
                table: "Projects",
                column: "DeveloperID",
                principalTable: "Developers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
