using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaiThiBNA.Migrations
{
    /// <inheritdoc />
    public partial class Cau3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BNA_Cau3",
                columns: table => new
                {
                    MaSv = table.Column<string>(type: "TEXT", nullable: false),
                    HoTen = table.Column<string>(type: "TEXT", nullable: false),
                    SDT = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BNA_Cau3", x => x.MaSv);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BNA_Cau3");
        }
    }
}
