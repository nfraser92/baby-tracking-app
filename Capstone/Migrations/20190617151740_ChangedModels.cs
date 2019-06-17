using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class ChangedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d3a03061-bea3-4055-a1f5-01a0121235cf", "AQAAAAEAACcQAAAAEJhylyi0xT3abu9qLCX6NoExAhvymkgWV64ASHrzH8YPom4o9iP2VlRM6njmeoU66Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f99814c7-4575-40a7-a532-a29e41592df2", "AQAAAAEAACcQAAAAECEenqlmq7EOoDScepwd3gnDKVQTtw3lz0LVrRXcZw/afZmmgWvfsdYJ15Nc5e0ixw==" });
        }
    }
}
