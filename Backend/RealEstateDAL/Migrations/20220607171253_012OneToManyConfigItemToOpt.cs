using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateDAL.Migrations
{
    public partial class _012OneToManyConfigItemToOpt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationsOptions_ConfigurationsItems_ConfigurationItemId",
                table: "ConfigurationsOptions");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationsOptions_ConfigurationItemId",
                table: "ConfigurationsOptions");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationsOptions_ConfigurationItemId",
                table: "ConfigurationsOptions",
                column: "ConfigurationItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationsOptions_ConfigurationsItems_ConfigurationItemId",
                table: "ConfigurationsOptions",
                column: "ConfigurationItemId",
                principalTable: "ConfigurationsItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationsOptions_ConfigurationsItems_ConfigurationItemId",
                table: "ConfigurationsOptions");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationsOptions_ConfigurationItemId",
                table: "ConfigurationsOptions");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationsOptions_ConfigurationItemId",
                table: "ConfigurationsOptions",
                column: "ConfigurationItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationsOptions_ConfigurationsItems_ConfigurationItemId",
                table: "ConfigurationsOptions",
                column: "ConfigurationItemId",
                principalTable: "ConfigurationsItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
