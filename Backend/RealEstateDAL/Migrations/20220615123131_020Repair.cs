using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateDAL.Migrations
{
    public partial class _020Repair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationsItems_PropertiesConfigurationsItems_PropertyConfigurationItemsID",
                table: "ConfigurationsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationsOptions_PropertiesConfigurationsItems_PropertyConfigurationItemsID",
                table: "ConfigurationsOptions");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationsOptions_PropertyConfigurationItemsID",
                table: "ConfigurationsOptions");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationsItems_PropertyConfigurationItemsID",
                table: "ConfigurationsItems");

            migrationBuilder.DropColumn(
                name: "PropertyConfigurationItemsID",
                table: "ConfigurationsOptions");

            migrationBuilder.DropColumn(
                name: "PropertyConfigurationItemsID",
                table: "ConfigurationsItems");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesConfigurationsItems_ConfigurationsOptions_ConfigurationOptionID",
                table: "PropertiesConfigurationsItems",
                column: "ConfigurationOptionID",
                principalTable: "ConfigurationsOptions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesConfigurationsItems_ConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesConfigurationsItems_ConfigurationsOptions_ConfigurationOptionID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationItemID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesConfigurationsItems_ConfigurationOptionID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.AddColumn<int>(
                name: "PropertyConfigurationItemsID",
                table: "ConfigurationsOptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyConfigurationItemsID",
                table: "ConfigurationsItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationsOptions_PropertyConfigurationItemsID",
                table: "ConfigurationsOptions",
                column: "PropertyConfigurationItemsID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationsOptions_PropertiesConfigurationsItems_PropertyConfigurationItemsID",
                table: "ConfigurationsOptions",
                column: "PropertyConfigurationItemsID",
                principalTable: "PropertiesConfigurationsItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
