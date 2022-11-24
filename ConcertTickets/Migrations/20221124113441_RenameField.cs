using Microsoft.EntityFrameworkCore.Migrations;

namespace ConcertTickets.Migrations
{
    public partial class RenameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgeLimitt",
                table: "Concerts",
                newName: "AgeLimit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgeLimit",
                table: "Concerts",
                newName: "AgeLimitt");
        }
    }
}
