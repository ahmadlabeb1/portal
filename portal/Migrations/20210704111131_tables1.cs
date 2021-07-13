using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class tables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Lang_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lang_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lang_key = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Lang_Id);
                });

            migrationBuilder.CreateTable(
                name: "NavigationItem",
                columns: table => new
                {
                    Nav_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nav_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nav_url = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Lang_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationItem", x => x.Nav_id);
                    table.ForeignKey(
                        name: "FK_NavigationItem_Language_Lang_id",
                        column: x => x.Lang_id,
                        principalTable: "Language",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubNavigationItem",
                columns: table => new
                {
                    subNav_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subNav_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    subNav_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Lang_id = table.Column<int>(type: "int", nullable: false),
                    Nav_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubNavigationItem", x => x.subNav_id);
                    table.ForeignKey(
                        name: "FK_SubNavigationItem_NavigationItem_Nav_id",
                        column: x => x.Nav_id,
                        principalTable: "NavigationItem",
                        principalColumn: "Nav_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NavigationItem_Lang_id",
                table: "NavigationItem",
                column: "Lang_id");

            migrationBuilder.CreateIndex(
                name: "IX_SubNavigationItem_Nav_id",
                table: "SubNavigationItem",
                column: "Nav_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubNavigationItem");

            migrationBuilder.DropTable(
                name: "NavigationItem");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
