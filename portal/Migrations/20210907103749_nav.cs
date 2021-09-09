using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class nav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IconNav",
                columns: table => new
                {
                    id_IconNav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameHint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameNav = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urlNav = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconNav", x => x.id_IconNav);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IconNav");
        }
    }
}
