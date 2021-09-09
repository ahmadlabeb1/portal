using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class rel_nav_icon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "lang_Id",
                table: "IconNav",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IconNav_lang_Id",
                table: "IconNav",
                column: "lang_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IconNav_Language_lang_Id",
                table: "IconNav",
                column: "lang_Id",
                principalTable: "Language",
                principalColumn: "Lang_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IconNav_Language_lang_Id",
                table: "IconNav");

            migrationBuilder.DropIndex(
                name: "IX_IconNav_lang_Id",
                table: "IconNav");

            migrationBuilder.DropColumn(
                name: "lang_Id",
                table: "IconNav");
        }
    }
}
