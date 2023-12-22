using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlak.Api.Migrations
{
    public partial class addImageUrlandPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76a3dac5-9db8-40a6-bb3e-1e1fcec4eb6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91818a92-1fde-43c0-b8d4-8081e43a3955");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RealEstateImageUrl",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e313fce-d33a-4bf6-9338-bc4dc06f135b", "2d978988-7ec9-4960-84e0-a6e6e37c8a59", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb844817-b00a-40aa-b944-8b7f89c2a8b2", "638c4016-dcd5-492a-af53-c0bbc1cbeebb", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e313fce-d33a-4bf6-9338-bc4dc06f135b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb844817-b00a-40aa-b944-8b7f89c2a8b2");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "RealEstateImageUrl",
                table: "RealEstates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76a3dac5-9db8-40a6-bb3e-1e1fcec4eb6c", "bf5eaf69-35c9-43d4-8c0b-8b4d93807111", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91818a92-1fde-43c0-b8d4-8081e43a3955", "b912c65d-00a1-4f3e-8a6c-154b24cc3c57", "Admin", "ADMIN" });
        }
    }
}
