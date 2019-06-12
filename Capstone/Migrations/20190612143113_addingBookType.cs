using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addingBookType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BookType",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "186eb298-8621-4b6e-9717-eea8dd977fb4", "AQAAAAEAACcQAAAAEDx0KDAcF7VQ6NkXLuuxc28IYMCXQOPbzA1hq9gh88D+flic0z0uVa+g31qhQW1VlQ==" });

            migrationBuilder.InsertData(
                table: "BookType",
                columns: new[] { "BookTypeId", "Description", "UserId" },
                values: new object[] { 1, "Musical/Sounds", "4f555f8c-d5db-43b5-836c-ffffffffffff" });

            migrationBuilder.CreateIndex(
                name: "IX_BookType_UserId",
                table: "BookType",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookType_AspNetUsers_UserId",
                table: "BookType",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookType_AspNetUsers_UserId",
                table: "BookType");

            migrationBuilder.DropIndex(
                name: "IX_BookType_UserId",
                table: "BookType");

            migrationBuilder.DeleteData(
                table: "BookType",
                keyColumn: "BookTypeId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be306373-288e-4bd1-b2be-59c7d96c131e", "AQAAAAEAACcQAAAAEJWZZgW7VKIuAAmWESjDKF92MIBQxI8cZXDdbKDQtYMC3erY6N1H0v+FnN8XFywquw==" });
        }
    }
}
