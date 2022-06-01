using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.AppIdentityDbMigrations
{
    public partial class ChangeDefaultUserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bda792d3-6d39-426f-8051-1d5615bced82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3ad054b-0c85-4efa-8457-edf10a67ca2a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "33d090af-a508-460e-9132-f01b6093568c", "1a6434f0-84ec-4a94-9020-652bb573bd7f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a6434f0-84ec-4a94-9020-652bb573bd7f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33d090af-a508-460e-9132-f01b6093568c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2fc87ce1-c496-41e3-ba62-f992ecb602dc", "7d74e597-3ed3-4284-b717-e5aaed954252", "user", "USER" },
                    { "bf5dc076-c594-4068-850a-353a39d5140b", "8729d111-2686-422c-99d1-800f6c9466e2", "manager", "MANAGER" },
                    { "0eee30e1-da42-4c80-9312-96b3f4a89997", "a4967b28-b939-4585-890e-970dc91f30f9", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0b52e6cf-8c47-442f-8e29-f2b753fa3ebf", 0, "49139f55-0467-49a8-aa9d-8839547726c3", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "SAMHYDE", "AQAAAAEAACcQAAAAEGgsV8BuK7wIkzQpkbLazIX6qiE4JCAXIyk7Y9l9JmGDqWqcpCaf3lx12sRJtUH32Q==", null, false, "", false, "SamHyde" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0b52e6cf-8c47-442f-8e29-f2b753fa3ebf", "0eee30e1-da42-4c80-9312-96b3f4a89997" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fc87ce1-c496-41e3-ba62-f992ecb602dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf5dc076-c594-4068-850a-353a39d5140b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0b52e6cf-8c47-442f-8e29-f2b753fa3ebf", "0eee30e1-da42-4c80-9312-96b3f4a89997" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eee30e1-da42-4c80-9312-96b3f4a89997");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0b52e6cf-8c47-442f-8e29-f2b753fa3ebf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d3ad054b-0c85-4efa-8457-edf10a67ca2a", "4cbd54e9-c321-400c-92ec-6159b3aec8cf", "user", "USER" },
                    { "bda792d3-6d39-426f-8051-1d5615bced82", "a6d01d27-71b2-4208-b53e-4321a599e47b", "manager", "MANAGER" },
                    { "1a6434f0-84ec-4a94-9020-652bb573bd7f", "cce3479f-8328-466d-a3e5-0fa4a6d8fbdd", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "33d090af-a508-460e-9132-f01b6093568c", 0, "fee53fb7-76a1-405a-9571-9bcf40383293", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEFmSdiFgngAoiyaYJ1rC1lNcGIAToXUu1sxOwFz4Dp3RQJToOVayU+wCuboH8XAzWw==", null, false, "", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "33d090af-a508-460e-9132-f01b6093568c", "1a6434f0-84ec-4a94-9020-652bb573bd7f" });
        }
    }
}
