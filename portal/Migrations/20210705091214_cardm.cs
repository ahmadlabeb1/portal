using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class cardm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardMultiAdv",
                columns: table => new
                {
                    Id_CardM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageCard = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Id_lang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardMultiAdv", x => x.Id_CardM);
                    table.ForeignKey(
                        name: "FK_CardMultiAdv_Language_Id_lang",
                        column: x => x.Id_lang,
                        principalTable: "Language",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });     

            migrationBuilder.CreateIndex(
                name: "IX_CardMultiAdv_Id_lang",
                table: "CardMultiAdv",
                column: "Id_lang");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardMultiAdv");
        }
    }
}
