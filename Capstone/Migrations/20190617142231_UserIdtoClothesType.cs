using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class UserIdtoClothesType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ClothesType",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f99814c7-4575-40a7-a532-a29e41592df2", "AQAAAAEAACcQAAAAECEenqlmq7EOoDScepwd3gnDKVQTtw3lz0LVrRXcZw/afZmmgWvfsdYJ15Nc5e0ixw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ClothesType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "139cc481-51f6-4a12-bb35-2f0705bf37e7", "AQAAAAEAACcQAAAAEPd3fp0LIE4qVkWkS3A/8Y5Z+D02hTeRDeahNvAo7Wb9Avi4+HLXHnXpex7q6ehRTg==" });
        }
    }
}
