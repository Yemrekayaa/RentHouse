using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_HouseImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseImages",
                columns: table => new
                {
                    HouseImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseID = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseImages", x => x.HouseImageID);
                    table.ForeignKey(
                        name: "FK_HouseImages_Houses_HouseID",
                        column: x => x.HouseID,
                        principalTable: "Houses",
                        principalColumn: "HouseID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseImages_HouseID",
                table: "HouseImages",
                column: "HouseID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseImages");
        }
    }
}
