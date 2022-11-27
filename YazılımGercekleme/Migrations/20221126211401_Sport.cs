using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YazılımGercekleme.Migrations
{
    public partial class Sport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    AthleteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AthleteNum = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    AthleteName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AthleteSurname = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Dates = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.AthleteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
