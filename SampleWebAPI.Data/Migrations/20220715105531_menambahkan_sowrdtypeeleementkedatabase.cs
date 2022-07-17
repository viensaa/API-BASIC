using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class menambahkan_sowrdtypeeleementkedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Quotes",
                newName: "text");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Quotes",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SwordName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SamuraiId = table.Column<int>(type: "int", nullable: false),
                    ElementiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sword_Samurais_SamuraiId",
                        column: x => x.SamuraiId,
                        principalTable: "Samurais",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementSword",
                columns: table => new
                {
                    ElementsId = table.Column<int>(type: "int", nullable: false),
                    swordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementSword", x => new { x.ElementsId, x.swordsId });
                    table.ForeignKey(
                        name: "FK_ElementSword_Element_ElementsId",
                        column: x => x.ElementsId,
                        principalTable: "Element",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementSword_Sword_swordsId",
                        column: x => x.swordsId,
                        principalTable: "Sword",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeSword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Type_Sword_SwordId",
                        column: x => x.SwordId,
                        principalTable: "Sword",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementSword_swordsId",
                table: "ElementSword",
                column: "swordsId");

            migrationBuilder.CreateIndex(
                name: "IX_Sword_SamuraiId",
                table: "Sword",
                column: "SamuraiId");

            migrationBuilder.CreateIndex(
                name: "IX_Type_SwordId",
                table: "Type",
                column: "SwordId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementSword");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "Sword");

            migrationBuilder.RenameColumn(
                name: "text",
                table: "Quotes",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Quotes",
                newName: "Id");
        }
    }
}
