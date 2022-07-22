using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class fixing_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Element_ElementsId",
                table: "ElementSword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Element",
                table: "Element");

            migrationBuilder.RenameTable(
                name: "Element",
                newName: "element");

            migrationBuilder.RenameColumn(
                name: "ElementsId",
                table: "ElementSword",
                newName: "ElementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_element",
                table: "element",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_element_ElementId",
                table: "ElementSword",
                column: "ElementId",
                principalTable: "element",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_element_ElementId",
                table: "ElementSword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_element",
                table: "element");

            migrationBuilder.RenameTable(
                name: "element",
                newName: "Element");

            migrationBuilder.RenameColumn(
                name: "ElementId",
                table: "ElementSword",
                newName: "ElementsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Element",
                table: "Element",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Element_ElementsId",
                table: "ElementSword",
                column: "ElementsId",
                principalTable: "Element",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
