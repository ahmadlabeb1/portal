using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class NavTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Navigation",
                columns: table => new
                {
                    Nav_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nav_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nav_Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nav_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    lang_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Navigation", x => x.Nav_Id);
                    table.ForeignKey(
                        name: "FK_Navigation_Language_lang_id",
                        column: x => x.lang_id,
                        principalTable: "Language",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Navigation_lang_id",
                table: "Navigation",
                column: "lang_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Navigation");
        }
    }
}
