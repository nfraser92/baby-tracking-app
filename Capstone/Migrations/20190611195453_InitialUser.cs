using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class InitialUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName", "StreetAddress" },
                values: new object[] { "4f555f8c-d5db-43b5-836c-ffffffffffff", 0, "be306373-288e-4bd1-b2be-59c7d96c131e", "ApplicationUser", "niall@niall.com", true, false, null, "NIALL@NIALL.COM", "NIALL@NIALL.COM", "AQAAAAEAACcQAAAAEJWZZgW7VKIuAAmWESjDKF92MIBQxI8cZXDdbKDQtYMC3erY6N1H0v+FnN8XFywquw==", null, false, "4f555f8c-d5db-43b5-836c-aaaaaaaaaaaa", false, "niall@niall.com", "Niall", "Fraser", "123 Infinity Way" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4f555f8c-d5db-43b5-836c-ffffffffffff");
        }
    }
}
