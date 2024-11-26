using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_location_settings_house : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Houses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Houses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Houses");
        }
    }
}
