using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_setting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    SettingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BannerID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.SettingID);
                    table.ForeignKey(
                        name: "FK_Settings_Banners_BannerID1",
                        column: x => x.BannerID1,
                        principalTable: "Banners",
                        principalColumn: "BannerID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Settings_BannerID1",
                table: "Settings",
                column: "BannerID1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
