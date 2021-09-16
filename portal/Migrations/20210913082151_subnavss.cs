using Microsoft.EntityFrameworkCore.Migrations;

namespace portal.Migrations
{
    public partial class subnavss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subNameNav_NameNav_NavName_id",
                table: "subNameNav");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subNameNav",
                table: "subNameNav");

            migrationBuilder.RenameTable(
                name: "subNameNav",
                newName: "SubNameNav");

            migrationBuilder.RenameIndex(
                name: "IX_subNameNav_NavName_id",
                table: "SubNameNav",
                newName: "IX_SubNameNav_NavName_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubNameNav",
                table: "SubNameNav",
                column: "Id_subNav");

            migrationBuilder.AddForeignKey(
                name: "FK_SubNameNav_NameNav_NavName_id",
                table: "SubNameNav",
                column: "NavName_id",
                principalTable: "NameNav",
                principalColumn: "Id_nameNav",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubNameNav_NameNav_NavName_id",
                table: "SubNameNav");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubNameNav",
                table: "SubNameNav");

            migrationBuilder.RenameTable(
                name: "SubNameNav",
                newName: "subNameNav");

            migrationBuilder.RenameIndex(
                name: "IX_SubNameNav_NavName_id",
                table: "subNameNav",
                newName: "IX_subNameNav_NavName_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subNameNav",
                table: "subNameNav",
                column: "Id_subNav");

            migrationBuilder.AddForeignKey(
                name: "FK_subNameNav_NameNav_NavName_id",
                table: "subNameNav",
                column: "NavName_id",
                principalTable: "NameNav",
                principalColumn: "Id_nameNav",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
