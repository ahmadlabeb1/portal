using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class NavTableedit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isGroup",
                table: "Navigation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isGroup",
                table: "Navigation",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
