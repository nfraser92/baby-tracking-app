using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class keepVSHappy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SearchId",
                table: "ToyType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SearchId",
                table: "Toy",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SearchId",
                table: "Clothes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SearchId",
                table: "BookType",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SearchId",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Search",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ToyId = table.Column<int>(nullable: true),
                    ToyTypeId = table.Column<int>(nullable: true),
                    BookTypeId = table.Column<int>(nullable: true),
                    BookId = table.Column<int>(nullable: true),
                    ClothesId = table.Column<int>(nullable: true),
                    SearchString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Search", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Search_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Search_BookType_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "BookType",
                        principalColumn: "BookTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Search_Clothes_ClothesId",
                        column: x => x.ClothesId,
                        principalTable: "Clothes",
                        principalColumn: "ClothesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Search_Toy_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toy",
                        principalColumn: "ToyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Search_ToyType_ToyTypeId",
                        column: x => x.ToyTypeId,
                        principalTable: "ToyType",
                        principalColumn: "ToyTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1ff4f133-bf12-4fe2-bbe1-2b39c3d2638c", "AQAAAAEAACcQAAAAED4RYQn8GOBGvr4Au35eD0YiZuMDYaKVuf8/SNONR1UEHZnja6T6js0V7v6xEsFrjg==" });

            migrationBuilder.CreateIndex(
                name: "IX_ToyType_SearchId",
                table: "ToyType",
                column: "SearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Toy_SearchId",
                table: "Toy",
                column: "SearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_SearchId",
                table: "Clothes",
                column: "SearchId");

            migrationBuilder.CreateIndex(
                name: "IX_BookType_SearchId",
                table: "BookType",
                column: "SearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_SearchId",
                table: "Book",
                column: "SearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Search_BookId",
                table: "Search",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Search_BookTypeId",
                table: "Search",
                column: "BookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Search_ClothesId",
                table: "Search",
                column: "ClothesId");

            migrationBuilder.CreateIndex(
                name: "IX_Search_ToyId",
                table: "Search",
                column: "ToyId");

            migrationBuilder.CreateIndex(
                name: "IX_Search_ToyTypeId",
                table: "Search",
                column: "ToyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Search_SearchId",
                table: "Book",
                column: "SearchId",
                principalTable: "Search",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookType_Search_SearchId",
                table: "BookType",
                column: "SearchId",
                principalTable: "Search",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clothes_Search_SearchId",
                table: "Clothes",
                column: "SearchId",
                principalTable: "Search",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Toy_Search_SearchId",
                table: "Toy",
                column: "SearchId",
                principalTable: "Search",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToyType_Search_SearchId",
                table: "ToyType",
                column: "SearchId",
                principalTable: "Search",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Search_SearchId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_BookType_Search_SearchId",
                table: "BookType");

            migrationBuilder.DropForeignKey(
                name: "FK_Clothes_Search_SearchId",
                table: "Clothes");

            migrationBuilder.DropForeignKey(
                name: "FK_Toy_Search_SearchId",
                table: "Toy");

            migrationBuilder.DropForeignKey(
                name: "FK_ToyType_Search_SearchId",
                table: "ToyType");

            migrationBuilder.DropTable(
                name: "Search");

            migrationBuilder.DropIndex(
                name: "IX_ToyType_SearchId",
                table: "ToyType");

            migrationBuilder.DropIndex(
                name: "IX_Toy_SearchId",
                table: "Toy");

            migrationBuilder.DropIndex(
                name: "IX_Clothes_SearchId",
                table: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_BookType_SearchId",
                table: "BookType");

            migrationBuilder.DropIndex(
                name: "IX_Book_SearchId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "SearchId",
                table: "ToyType");

            migrationBuilder.DropColumn(
                name: "SearchId",
                table: "Toy");

            migrationBuilder.DropColumn(
                name: "SearchId",
                table: "Clothes");

            migrationBuilder.DropColumn(
                name: "SearchId",
                table: "BookType");

            migrationBuilder.DropColumn(
                name: "SearchId",
                table: "Book");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2c4fedb-d3bb-4fde-8349-f2b050cd2650", "AQAAAAEAACcQAAAAEDZ0rv7iWbEPt6772VR6hlF62frHdSV7k7qtZWcYeICUWrpPKAjNJWZS9oLA33g9Bg==" });
        }
    }
}
