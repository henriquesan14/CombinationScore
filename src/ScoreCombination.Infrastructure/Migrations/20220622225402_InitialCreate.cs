using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScoreCombination.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScoresCombinations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    Request = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoresCombinations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoresCombinations");
        }
    }
}
