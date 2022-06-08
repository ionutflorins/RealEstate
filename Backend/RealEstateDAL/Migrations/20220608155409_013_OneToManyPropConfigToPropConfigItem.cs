using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateDAL.Migrations
{
    public partial class _013_OneToManyPropConfigToPropConfigItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesConfigurationsItems_PropertiesConfigurations_PropertyConfigurationID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesConfigurationsItems_PropertyConfigurationID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesConfigurationsItems_PropertyConfigurationID",
                table: "PropertiesConfigurationsItems",
                column: "PropertyConfigurationID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesConfigurationsItems_PropertiesConfigurations_PropertyConfigurationID",
                table: "PropertiesConfigurationsItems",
                column: "PropertyConfigurationID",
                principalTable: "PropertiesConfigurations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesConfigurationsItems_PropertiesConfigurations_PropertyConfigurationID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.DropIndex(
                name: "IX_PropertiesConfigurationsItems_PropertyConfigurationID",
                table: "PropertiesConfigurationsItems");

            migrationBuilder.CreateIndex(
                name: "IX_PropertiesConfigurationsItems_PropertyConfigurationID",
                table: "PropertiesConfigurationsItems",
                column: "PropertyConfigurationID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesConfigurationsItems_PropertiesConfigurations_PropertyConfigurationID",
                table: "PropertiesConfigurationsItems",
                column: "PropertyConfigurationID",
                principalTable: "PropertiesConfigurations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
