using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class subnavs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subNameNav",
                columns: table => new
                {
                    Id_subNav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameSubNav = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavName_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subNameNav", x => x.Id_subNav);
                    table.ForeignKey(
                        name: "FK_subNameNav_NameNav_NavName_id",
                        column: x => x.NavName_id,
                        principalTable: "NameNav",
                        principalColumn: "Id_nameNav",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_subNameNav_NavName_id",
                table: "subNameNav",
                column: "NavName_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subNameNav");
        }
    }
}
