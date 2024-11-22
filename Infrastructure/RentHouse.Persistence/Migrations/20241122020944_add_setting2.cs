using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_setting2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Banners_BannerID1",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_BannerID1",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BannerID1",
                table: "Settings");

            migrationBuilder.AlterColumn<int>(
                name: "BannerID",
                table: "Settings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settings_BannerID",
                table: "Settings",
                column: "BannerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Banners_BannerID",
                table: "Settings",
                column: "BannerID",
                principalTable: "Banners",
                principalColumn: "BannerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Banners_BannerID",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_BannerID",
                table: "Settings");

            migrationBuilder.AlterColumn<string>(
                name: "BannerID",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BannerID1",
                table: "Settings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Settings_BannerID1",
                table: "Settings",
                column: "BannerID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Banners_BannerID1",
                table: "Settings",
                column: "BannerID1",
                principalTable: "Banners",
                principalColumn: "BannerID");
        }
    }
}
