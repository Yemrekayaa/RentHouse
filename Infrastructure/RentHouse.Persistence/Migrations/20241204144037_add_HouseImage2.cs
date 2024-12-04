using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_HouseImage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BigImageUrl",
                table: "Houses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BigImageUrl",
                table: "Houses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
