using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addingaftermergeconflicts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "930f6459-3ec6-48ec-8274-1d581cc9745f", "AQAAAAEAACcQAAAAEAQN5sMyTktEuRywDErE2aNhU+TN/l4bwXT2Q81PELFyasp9PQgbFUXfcVn9/JC6wQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d3a03061-bea3-4055-a1f5-01a0121235cf", "AQAAAAEAACcQAAAAEJhylyi0xT3abu9qLCX6NoExAhvymkgWV64ASHrzH8YPom4o9iP2VlRM6njmeoU66Q==" });
        }
    }
}
