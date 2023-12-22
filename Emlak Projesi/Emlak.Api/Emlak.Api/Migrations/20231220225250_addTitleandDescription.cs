using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emlak.Api.Migrations
{
    public partial class addTitleandDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e313fce-d33a-4bf6-9338-bc4dc06f135b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb844817-b00a-40aa-b944-8b7f89c2a8b2");

            migrationBuilder.AddColumn<string>(
                name: "Desciption",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "RealEstates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "17f2785f-0962-4ecc-a738-5d0b8a73111a", "7bc2c1ff-bb51-41c9-9be8-6242bc5d692d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56aa983f-ea25-4ced-a074-1eef65afe41b", "32a508b2-f047-420a-92a2-ff109d2fb74c", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17f2785f-0962-4ecc-a738-5d0b8a73111a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56aa983f-ea25-4ced-a074-1eef65afe41b");

            migrationBuilder.DropColumn(
                name: "Desciption",
                table: "RealEstates");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "RealEstates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e313fce-d33a-4bf6-9338-bc4dc06f135b", "2d978988-7ec9-4960-84e0-a6e6e37c8a59", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "eb844817-b00a-40aa-b944-8b7f89c2a8b2", "638c4016-dcd5-492a-af53-c0bbc1cbeebb", "Admin", "ADMIN" });
        }
    }
}
