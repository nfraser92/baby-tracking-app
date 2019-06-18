using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedsingleinstanceofitemsintogiftideas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Search",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClothesId",
                table: "Search",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToyId",
                table: "Search",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b947f8ab-c2d9-47c4-bbcd-38de47307cab", "AQAAAAEAACcQAAAAECJMjiQstFY4Q+Rb7NDg+0hkex7F5l8QEwYYdUJAqL16T2KUAwAMH8AYFO6rbIXX+g==" });

            migrationBuilder.CreateIndex(
                name: "IX_Search_BookId",
                table: "Search",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Search_ClothesId",
                table: "Search",
                column: "ClothesId");

            migrationBuilder.CreateIndex(
                name: "IX_Search_ToyId",
                table: "Search",
                column: "ToyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Search_Book_BookId",
                table: "Search",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Search_Clothes_ClothesId",
                table: "Search",
                column: "ClothesId",
                principalTable: "Clothes",
                principalColumn: "ClothesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Search_Toy_ToyId",
                table: "Search",
                column: "ToyId",
                principalTable: "Toy",
                principalColumn: "ToyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Search_Book_BookId",
                table: "Search");

            migrationBuilder.DropForeignKey(
                name: "FK_Search_Clothes_ClothesId",
                table: "Search");

            migrationBuilder.DropForeignKey(
                name: "FK_Search_Toy_ToyId",
                table: "Search");

            migrationBuilder.DropIndex(
                name: "IX_Search_BookId",
                table: "Search");

            migrationBuilder.DropIndex(
                name: "IX_Search_ClothesId",
                table: "Search");

            migrationBuilder.DropIndex(
                name: "IX_Search_ToyId",
                table: "Search");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Search");

            migrationBuilder.DropColumn(
                name: "ClothesId",
                table: "Search");

            migrationBuilder.DropColumn(
                name: "ToyId",
                table: "Search");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "180a7e56-b147-4004-bcf4-4cbb7c2c9be2", "AQAAAAEAACcQAAAAEPq6p2RlajqKPZzn5Nwks6ZxHUqpSmw20ywYa6q0HrXbjznsIh37rSSYndjpMnQhmA==" });
        }
    }
}
