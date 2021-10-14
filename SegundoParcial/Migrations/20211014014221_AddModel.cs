using Microsoft.EntityFrameworkCore.Migrations;

namespace SegundoParcial.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magic",
                columns: table => new
                {
                    FuturoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Vision = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magic", x => x.FuturoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Magic");
        }
    }
}
