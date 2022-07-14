using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class menambahkanExplisitTabelDanPayload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Battles_BattlesBattleId",
                table: "BattleSamurai");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Samurais_Samuraisid",
                table: "BattleSamurai");

            migrationBuilder.RenameColumn(
                name: "Samuraisid",
                table: "BattleSamurai",
                newName: "SamuraiId");

            migrationBuilder.RenameColumn(
                name: "BattlesBattleId",
                table: "BattleSamurai",
                newName: "BattleId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleSamurai_Samuraisid",
                table: "BattleSamurai",
                newName: "IX_BattleSamurai_SamuraiId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateJoined",
                table: "BattleSamurai",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Battles_BattleId",
                table: "BattleSamurai",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "BattleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraiId",
                table: "BattleSamurai",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Battles_BattleId",
                table: "BattleSamurai");

            migrationBuilder.DropForeignKey(
                name: "FK_BattleSamurai_Samurais_SamuraiId",
                table: "BattleSamurai");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "BattleSamurai");

            migrationBuilder.RenameColumn(
                name: "SamuraiId",
                table: "BattleSamurai",
                newName: "Samuraisid");

            migrationBuilder.RenameColumn(
                name: "BattleId",
                table: "BattleSamurai",
                newName: "BattlesBattleId");

            migrationBuilder.RenameIndex(
                name: "IX_BattleSamurai_SamuraiId",
                table: "BattleSamurai",
                newName: "IX_BattleSamurai_Samuraisid");

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Battles_BattlesBattleId",
                table: "BattleSamurai",
                column: "BattlesBattleId",
                principalTable: "Battles",
                principalColumn: "BattleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BattleSamurai_Samurais_Samuraisid",
                table: "BattleSamurai",
                column: "Samuraisid",
                principalTable: "Samurais",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
