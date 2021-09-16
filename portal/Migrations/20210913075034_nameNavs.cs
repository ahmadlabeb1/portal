using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class nameNavs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NameNav",
                columns: table => new
                {
                    Id_nameNav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameNav = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lang_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameNav", x => x.Id_nameNav);
                    table.ForeignKey(
                        name: "FK_NameNav_Language_Lang_id",
                        column: x => x.Lang_id,
                        principalTable: "Language",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NameNav_Lang_id",
                table: "NameNav",
                column: "Lang_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NameNav");
        }
    }
}
