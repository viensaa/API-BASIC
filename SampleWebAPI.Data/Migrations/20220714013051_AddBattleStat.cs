using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class AddBattleStat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE FUNCTION[dbo].[EarliestBattleFoughtBySamurai](@samuraiId int)
                RETURNS char(30) AS
                BEGIN
                  DECLARE @ret char(30)
                  SELECT TOP 1 @ret = Name
                  FROM Battles
                  WHERE Battles.BattleId IN(SELECT BattleId
                                     FROM BattleSamurai
                                    WHERE SamuraiId = @samuraiId)
                  ORDER BY BattleId asc
                  RETURN @ret
                END");
            migrationBuilder.Sql(@"CREATE VIEW dbo.SamuraiBattleStats
              AS
              SELECT dbo.Samurais.Name,
              COUNT(dbo.BattleSamurai.BattleId) AS NumberOfBattles,
                      dbo.EarliestBattleFoughtBySamurai(MIN(dbo.Samurais.Id)) 
		  	     AS EarliestBattle
              FROM dbo.BattleSamurai INNER JOIN
                   dbo.Samurais ON dbo.BattleSamurai.SamuraiId = dbo.Samurais.Id
              GROUP BY dbo.Samurais.Name, dbo.BattleSamurai.SamuraiId");
        
    }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view dbo.SamuraiBattleStats");
            migrationBuilder.Sql(@"drop function dbo.EarliestBattleFoughtBySamurai");
        }
    }
}
