using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_pricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pricings_HouseID",
                table: "Pricings");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_HouseID",
                table: "Pricings",
                column: "HouseID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pricings_HouseID",
                table: "Pricings");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_HouseID",
                table: "Pricings",
                column: "HouseID");
        }
    }
}
