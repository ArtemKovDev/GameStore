using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.AppIdentityDbMigrations
{
    public partial class AddDefaultAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c9e6679-7425-40de-944b-e07fc1f90ae7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7c9e6679-7425-40de-944b-e07fc1f90ae7", "c5eba362-c387-490c-b609-10a071dd691a", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "ae71da74-fbed-424e-944d-8f0adfb87041", "manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", "b6f65931-ccbe-4e27-b967-b14071a7950d", "admin", "ADMIN" });
        }
    }
}
