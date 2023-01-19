using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConcertTickets.Migrations
{
    public partial class Added_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    ConcertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupOrArtistName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TicketsCount = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VoiceType = table.Column<int>(type: "int", nullable: true),
                    ConcertName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    СomposerName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    HeadLiner = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    HowToGetTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeLimit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.ConcertId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concerts");
        }
    }
}
