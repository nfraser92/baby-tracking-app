using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class beforeDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0956454b-4123-4392-a164-a745b15e086d", "AQAAAAEAACcQAAAAEFMkGpFvely9j4oAVjBv0dZtIeh8+Z0oKWCENCrkhIBQeV4Rp/Wqm9gqP1/aMX1zOA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d7e17c2-a169-491a-b38f-9e19237304ae", "AQAAAAEAACcQAAAAEECfz4n3vVhSeX6oLs/Q/4nvpG2KfMkaWiNsRgg0mCky0vPIa1xrQTIcg6GtS+MwEw==" });
        }
    }
}
