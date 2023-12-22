using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlak.Api.Migrations
{
    public partial class addRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76a3dac5-9db8-40a6-bb3e-1e1fcec4eb6c", "bf5eaf69-35c9-43d4-8c0b-8b4d93807111", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91818a92-1fde-43c0-b8d4-8081e43a3955", "b912c65d-00a1-4f3e-8a6c-154b24cc3c57", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76a3dac5-9db8-40a6-bb3e-1e1fcec4eb6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91818a92-1fde-43c0-b8d4-8081e43a3955");
        }
    }
}
