using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedUserIdToGiftIdeasModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "139cc481-51f6-4a12-bb35-2f0705bf37e7", "AQAAAAEAACcQAAAAEPd3fp0LIE4qVkWkS3A/8Y5Z+D02hTeRDeahNvAo7Wb9Avi4+HLXHnXpex7q6ehRTg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03ab4851-1111-49f4-a40b-9dd44d898637", "AQAAAAEAACcQAAAAEL3FSOyj0O9L8JXpKYPPDnRB49urO1h1IEmU9BMcRt1Dpcxpegfp/CQaHAGUVKxiFQ==" });
        }
    }
}
