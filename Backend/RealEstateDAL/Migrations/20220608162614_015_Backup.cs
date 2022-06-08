using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateDAL.Migrations
{
    public partial class _015_Backup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationsItems_PropertiesConfigurationsItems_PropertyConfigurationItemsID",
                table: "ConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationsItems_PropertyConfigurationItemsID",
                table: "ConfigurationsItems");

            migrationBuilder.DropColumn(
                name: "PropertyConfigurationItemsID",
                table: "ConfigurationsItems");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems",
                column: "ConfigurationItemID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesConfigurationsItems_ConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems",
                column: "ConfigurationItemID",
                principalTable: "ConfigurationsItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesConfigurationsItems_ConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.AddColumn<int>(
                name: "PropertyConfigurationItemsID",
                table: "ConfigurationsItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationsItems_PropertyConfigurationItemsID",
                table: "ConfigurationsItems",
                column: "PropertyConfigurationItemsID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationsItems_PropertiesConfigurationsItems_PropertyConfigurationItemsID",
                table: "ConfigurationsItems",
                column: "PropertyConfigurationItemsID",
                principalTable: "PropertiesConfigurationsItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
