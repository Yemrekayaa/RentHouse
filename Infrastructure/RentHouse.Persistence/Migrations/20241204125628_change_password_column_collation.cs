using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentHouse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class change_password_column_collation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Password sütununun COLLATE ayarını değiştiren SQL komutu
            migrationBuilder.Sql(
                "ALTER TABLE AppUsers ALTER COLUMN Password NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CS_AS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eğer geri almak isterseniz, COLLATE'yi eski haline döndürebilirsiniz
            migrationBuilder.Sql(
                "ALTER TABLE AppUsers ALTER COLUMN Password NVARCHAR(50) COLLATE SQL_Latin1_General_CP1_CI_AS");
        }
    }
}
