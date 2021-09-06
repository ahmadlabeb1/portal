using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubNavigationItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubNavigationItem",
                columns: table => new
                {
                    subNav_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lang_id = table.Column<int>(type: "int", nullable: false),
                    Nav_id = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    subNav_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subNav_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubNavigationItem", x => x.subNav_id);
                    table.ForeignKey(
                        name: "FK_SubNavigationItem_Language_Lang_id",
                        column: x => x.Lang_id,
                        principalTable: "Language",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubNavigationItem_NavigationItem_Nav_id",
                        column: x => x.Nav_id,
                        principalTable: "NavigationItem",
                        principalColumn: "Nav_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubNavigationItem_Lang_id",
                table: "SubNavigationItem",
                column: "Lang_id");

            migrationBuilder.CreateIndex(
                name: "IX_SubNavigationItem_Nav_id",
                table: "SubNavigationItem",
                column: "Nav_id");
        }
    }
}
