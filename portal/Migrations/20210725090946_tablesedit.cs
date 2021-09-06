 using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class tablesedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_SubNavigationItem_Nav_id",
                table: "SubNavigationItem",
                column: "Nav_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubNavigationItem");
        }
    }
}
