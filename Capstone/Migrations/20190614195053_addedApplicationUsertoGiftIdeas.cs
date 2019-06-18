using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedApplicationUsertoGiftIdeas : Migration
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "GiftIdeas",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03ab4851-1111-49f4-a40b-9dd44d898637", "AQAAAAEAACcQAAAAEL3FSOyj0O9L8JXpKYPPDnRB49urO1h1IEmU9BMcRt1Dpcxpegfp/CQaHAGUVKxiFQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_GiftIdeas_UserId",
                table: "GiftIdeas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftIdeas_AspNetUsers_UserId",
                table: "GiftIdeas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiftIdeas_AspNetUsers_UserId",
                table: "GiftIdeas");

            migrationBuilder.DropIndex(
                name: "IX_GiftIdeas_UserId",
                table: "GiftIdeas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GiftIdeas");

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
