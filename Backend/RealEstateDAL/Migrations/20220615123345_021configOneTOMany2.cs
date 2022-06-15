using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateDAL.Migrations
{
    public partial class _021configOneTOMany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesConfigurationsItems_ConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationOptionID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems",
                column: "ConfigurationItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationOptionID",
                table: "PropertiesConfigurationsItems",
                column: "ConfigurationOptionID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesConfigurationsItems_ConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems",
                column: "ConfigurationItemID",
                principalTable: "ConfigurationsItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesConfigurationsItems_ConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationOptionID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems",
                column: "ConfigurationItemID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationOptionID",
                table: "PropertiesConfigurationsItems",
                column: "ConfigurationOptionID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesConfigurationsItems_ConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems",
                column: "ConfigurationItemID",
                principalTable: "ConfigurationsItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
