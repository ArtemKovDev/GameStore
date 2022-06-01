using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.ApplicationDbMigrations
{
    public partial class AddDefaultAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RegisteredUsers",
                columns: new[] { "Id", "FirstName", "ImageUrl", "LastName", "UserName" },
                values: new object[] { 1, "Admin", null, "First", "admin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RegisteredUsers",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
