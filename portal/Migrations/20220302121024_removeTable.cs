using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class removeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NameNav_Language_Lang_id",
                table: "NameNav");

            migrationBuilder.DropTable(
                name: "SubNameNav");

            migrationBuilder.DropIndex(
                name: "IX_NameNav_Lang_id",
                table: "NameNav");

            migrationBuilder.DropColumn(
                name: "Lang_id",
                table: "NameNav");

            migrationBuilder.AddColumn<int>(
                name: "LanguageLang_Id",
                table: "NameNav",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NameNav_LanguageLang_Id",
                table: "NameNav",
                column: "LanguageLang_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NameNav_Language_LanguageLang_Id",
                table: "NameNav",
                column: "LanguageLang_Id",
                principalTable: "Language",
                principalColumn: "Lang_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NameNav_Language_LanguageLang_Id",
                table: "NameNav");

            migrationBuilder.DropIndex(
                name: "IX_NameNav_LanguageLang_Id",
                table: "NameNav");

            migrationBuilder.DropColumn(
                name: "LanguageLang_Id",
                table: "NameNav");

            migrationBuilder.AddColumn<int>(
                name: "Lang_id",
                table: "NameNav",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubNameNav",
                columns: table => new
                {
                    Id_subNav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NavName_id = table.Column<int>(type: "int", nullable: false),
                    nameSubNav = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubNameNav", x => x.Id_subNav);
                    table.ForeignKey(
                        name: "FK_SubNameNav_NameNav_NavName_id",
                        column: x => x.NavName_id,
                        principalTable: "NameNav",
                        principalColumn: "Id_nameNav",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NameNav_Lang_id",
                table: "NameNav",
                column: "Lang_id");

            migrationBuilder.CreateIndex(
                name: "IX_SubNameNav_NavName_id",
                table: "SubNameNav",
                column: "NavName_id");

            migrationBuilder.AddForeignKey(
                name: "FK_NameNav_Language_Lang_id",
                table: "NameNav",
                column: "Lang_id",
                principalTable: "Language",
                principalColumn: "Lang_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
