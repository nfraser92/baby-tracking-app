using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class repeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4c5fece8-da6b-49a3-ae17-74a8cb25e59a", "AQAAAAEAACcQAAAAEDcpSEpwZoZLPaLwJF55qTXh53NvVtE8XcX/0uvKTbslRfM10YBCW7YQ+1czFKgMtA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b947f8ab-c2d9-47c4-bbcd-38de47307cab", "AQAAAAEAACcQAAAAECJMjiQstFY4Q+Rb7NDg+0hkex7F5l8QEwYYdUJAqL16T2KUAwAMH8AYFO6rbIXX+g==" });
        }
    }
}
