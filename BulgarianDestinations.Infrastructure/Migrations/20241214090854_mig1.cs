using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulgarianDestinations.Infrastructure.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7cb69f1d-5eaa-415d-810c-8ba62611b6a5", 0, "edb446e0-5e4d-47bb-bb0a-5e950c89b44d", "admin@mail.com", false, "Admin", "Adminov", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAENAUZ5pEAILSFELbPv+LlYy1Mdiwpf9q+pzD1urboaZmNYV9Gzxt7fL0uUmFBwYJow==", null, false, "7a1fac22-95d3-4352-bcb9-2b9fa975e3ec", false, "admin@mail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7cb69f1d-5eaa-415d-810c-8ba62611b6a5");
        }
    }
}
