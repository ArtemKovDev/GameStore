using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations.ApplicationDbMigrations
{
    public partial class AddDefaultPaymentTypesAndEmailField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "RegisteredUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Card" });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Cash" });

            migrationBuilder.UpdateData(
                table: "RegisteredUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName", "UserName" },
                values: new object[] { "admin@gmail.com", "Sam", "Hyde", "SamHyde" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Email",
                table: "RegisteredUsers");

            migrationBuilder.UpdateData(
                table: "RegisteredUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName", "UserName" },
                values: new object[] { "Admin", "First", "admin@gmail.com" });
        }
    }
}
