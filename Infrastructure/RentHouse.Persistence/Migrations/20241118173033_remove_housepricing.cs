using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class remove_housepricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HousePricings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pricings");

            migrationBuilder.AddColumn<int>(
                name: "HouseID",
                table: "Pricings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "WeekdayPrice",
                table: "Pricings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WeekendPrice",
                table: "Pricings",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_HouseID",
                table: "Pricings",
                column: "HouseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Houses_HouseID",
                table: "Pricings",
                column: "HouseID",
                principalTable: "Houses",
                principalColumn: "HouseID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Houses_HouseID",
                table: "Pricings");

            migrationBuilder.DropIndex(
                name: "IX_Pricings_HouseID",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "HouseID",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "WeekdayPrice",
                table: "Pricings");

            migrationBuilder.DropColumn(
                name: "WeekendPrice",
                table: "Pricings");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pricings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HousePricings",
                columns: table => new
                {
                    HousePricingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseID = table.Column<int>(type: "int", nullable: false),
                    PricingID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousePricings", x => x.HousePricingID);
                    table.ForeignKey(
                        name: "FK_HousePricings_Houses_HouseID",
                        column: x => x.HouseID,
                        principalTable: "Houses",
                        principalColumn: "HouseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HousePricings_Pricings_PricingID",
                        column: x => x.PricingID,
                        principalTable: "Pricings",
                        principalColumn: "PricingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HousePricings_HouseID",
                table: "HousePricings",
                column: "HouseID");

            migrationBuilder.CreateIndex(
                name: "IX_HousePricings_PricingID",
                table: "HousePricings",
                column: "PricingID");
        }
    }
}
