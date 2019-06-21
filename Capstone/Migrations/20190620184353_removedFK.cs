using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class removedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d7e17c2-a169-491a-b38f-9e19237304ae", "AQAAAAEAACcQAAAAEECfz4n3vVhSeX6oLs/Q/4nvpG2KfMkaWiNsRgg0mCky0vPIa1xrQTIcg6GtS+MwEw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb16a290-6c49-4bba-8889-9b4909b2b8ad", "AQAAAAEAACcQAAAAEOCR3fNzhYrRIGWn9M3Tvf1AN2oebMEZg9+0EQWLYLoJR3mx3QCkSO0iAAVWIDXo3A==" });
        }
    }
}
