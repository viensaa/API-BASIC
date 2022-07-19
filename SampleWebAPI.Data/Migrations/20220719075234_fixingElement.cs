using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class fixingElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Element",
                table: "Element",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Element_ElementId",
                table: "ElementSword",
                column: "ElementId",
                principalTable: "Element",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Element_ElementId",
                table: "ElementSword");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Element",
                table: "Element");

            migrationBuilder.RenameTable(
                name: "Element",
                newName: "element");

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
    }
}
