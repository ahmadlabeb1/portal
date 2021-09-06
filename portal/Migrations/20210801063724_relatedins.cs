using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class relatedins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RelatedIns",
                columns: table => new
                {
                    id_Related = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    images_Related = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    name_Related = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    link_Related = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    Lang_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedIns", x => x.id_Related);
                    table.ForeignKey(
                        name: "FK_RelatedIns_Language_Lang_id",
                        column: x => x.Lang_id,
                        principalTable: "Language",
                        principalColumn: "Lang_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedIns_Lang_id",
                table: "RelatedIns",
                column: "Lang_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatedIns");
        }
    }
}
