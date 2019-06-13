using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class removedRequiredFieldFromSizeInGiftIdeas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "GiftIdeas",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c84ea2be-3d03-48e3-ad3c-61a9286cae06", "AQAAAAEAACcQAAAAEIq3Th1VwGSSD6UyTvJ1sor4t4uaXiNb7Mnmjwgy1ub09IH1OCP6L1xHn82zAXtmKw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "GiftIdeas",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75d9e65a-0c69-4a59-86c9-a0ef3a2187a9", "AQAAAAEAACcQAAAAEOryTb1gEzxck0x9qKZ1NfV97OQw6jqGGMpCcaYHYqghpgjbhl9gyKvREOUuo7ezww==" });
        }
    }
}
