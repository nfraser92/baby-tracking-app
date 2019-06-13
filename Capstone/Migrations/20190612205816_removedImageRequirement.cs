using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class removedImageRequirement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Toy",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75d9e65a-0c69-4a59-86c9-a0ef3a2187a9", "AQAAAAEAACcQAAAAEOryTb1gEzxck0x9qKZ1NfV97OQw6jqGGMpCcaYHYqghpgjbhl9gyKvREOUuo7ezww==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Toy",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94626ba8-eab1-47b6-8d25-f340497b1d51", "AQAAAAEAACcQAAAAEN/aG0ElGNeN8Cm13skvsgSPfRJ9yXfTqOD80Bke5+fUtJaGC1L5qbLt7hlyJ3d2ow==" });
        }
    }
}
