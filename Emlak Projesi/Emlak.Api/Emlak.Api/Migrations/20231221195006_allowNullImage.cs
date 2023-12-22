using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlak.Api.Migrations
{
    public partial class allowNullImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "076e53e6-8d66-4111-97cc-c8abf650ed56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed08c684-a88d-467d-a63e-4735dd5a0160");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3e0842ae-6b87-4cc3-b038-1764c09776dc", "2382e911-aa5f-4694-ab1c-b3b6cc152108", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b9359ff-4b3a-423c-929e-e274cdf3f0d6", "9b5af882-b4e3-4501-8b18-ed4279835425", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e0842ae-6b87-4cc3-b038-1764c09776dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b9359ff-4b3a-423c-929e-e274cdf3f0d6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "076e53e6-8d66-4111-97cc-c8abf650ed56", "49d9219e-6e20-40d6-ba55-2e35144d422e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ed08c684-a88d-467d-a63e-4735dd5a0160", "919987d6-bc23-45de-a776-72386209a35b", "Admin", "ADMIN" });
        }
    }
}
