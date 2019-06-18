using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedTypesBackIntoSearchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Search");

            migrationBuilder.DropColumn(
                name: "ClothesId",
                table: "Search");

            migrationBuilder.DropColumn(
                name: "SearchString",
                table: "Search");

            migrationBuilder.RenameColumn(
                name: "ToyId",
                table: "Search",
                newName: "ClothesTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Search_ToyId",
                table: "Search",
                newName: "IX_Search_ClothesTypeId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "180a7e56-b147-4004-bcf4-4cbb7c2c9be2", "AQAAAAEAACcQAAAAEPq6p2RlajqKPZzn5Nwks6ZxHUqpSmw20ywYa6q0HrXbjznsIh37rSSYndjpMnQhmA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Search_ClothesType_ClothesTypeId",
                table: "Search",
                column: "ClothesTypeId",
                principalTable: "ClothesType",
                principalColumn: "ClothesTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Search_ClothesType_ClothesTypeId",
                table: "Search");

            migrationBuilder.RenameColumn(
                name: "ClothesTypeId",
                table: "Search",
                newName: "ToyId");

            migrationBuilder.RenameIndex(
                name: "IX_Search_ClothesTypeId",
                table: "Search",
                newName: "IX_Search_ToyId");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Search",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClothesId",
                table: "Search",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchString",
                table: "Search",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ff4f133-bf12-4fe2-bbe1-2b39c3d2638c", "AQAAAAEAACcQAAAAED4RYQn8GOBGvr4Au35eD0YiZuMDYaKVuf8/SNONR1UEHZnja6T6js0V7v6xEsFrjg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Search_BookId",
                table: "Search",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Search_ClothesId",
                table: "Search",
                column: "ClothesId");

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
    }
}
