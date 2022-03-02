using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IconNav");

            migrationBuilder.DropTable(
                name: "NameNav");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IconNav",
                columns: table => new
                {
                    id_IconNav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lang_Id = table.Column<int>(type: "int", nullable: false),
                    nameHint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameNav = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    urlNav = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconNav", x => x.id_IconNav);
                    table.ForeignKey(
                        name: "FK_IconNav_Language_lang_Id",
                        column: x => x.lang_Id,
                        principalTable: "Language",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NameNav",
                columns: table => new
                {
                    Id_nameNav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageLang_Id = table.Column<int>(type: "int", nullable: true),
                    nameNav = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NameNav", x => x.Id_nameNav);
                    table.ForeignKey(
                        name: "FK_NameNav_Language_LanguageLang_Id",
                        column: x => x.LanguageLang_Id,
                        principalTable: "Language",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IconNav_lang_Id",
                table: "IconNav",
                column: "lang_Id");

            migrationBuilder.CreateIndex(
                name: "IX_NameNav_LanguageLang_Id",
                table: "NameNav",
                column: "LanguageLang_Id");
        }
    }
}
