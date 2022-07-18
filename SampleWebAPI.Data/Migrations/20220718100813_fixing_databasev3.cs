using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class fixing_databasev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Sword_swordsId",
                table: "ElementSword");

            migrationBuilder.RenameColumn(
                name: "swordsId",
                table: "ElementSword",
                newName: "swordId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementSword_swordsId",
                table: "ElementSword",
                newName: "IX_ElementSword_swordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Sword_swordId",
                table: "ElementSword",
                column: "swordId",
                principalTable: "Sword",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Sword_swordId",
                table: "ElementSword");

            migrationBuilder.RenameColumn(
                name: "swordId",
                table: "ElementSword",
                newName: "swordsId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementSword_swordId",
                table: "ElementSword",
                newName: "IX_ElementSword_swordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Sword_swordsId",
                table: "ElementSword",
                column: "swordsId",
                principalTable: "Sword",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
