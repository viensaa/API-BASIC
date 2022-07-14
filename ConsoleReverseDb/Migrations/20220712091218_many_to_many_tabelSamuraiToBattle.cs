using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleReverseDb.Migrations
{
    public partial class many_to_many_tabelSamuraiToBattle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kuliah",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    lecturerId = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Matkul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    Nik = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kuliah");

            migrationBuilder.DropTable(
                name: "Lecturers");
        }
    }
}
