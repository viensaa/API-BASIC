using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class fixingv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElementiId",
                table: "Sword",
                newName: "ElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ElementId",
                table: "Sword",
                newName: "ElementiId");
        }
    }
}
