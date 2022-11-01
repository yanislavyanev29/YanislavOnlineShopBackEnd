using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YanislavOnlineShopBackEnd.Migrations
{
    public partial class ImageService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ImageUrl3",
                table: "Products",
                newName: "PublicId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "96d1ae6b-c320-42f3-9e7a-ab7b2df11305");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8581968d-c389-4b73-a0d4-b3a40e07fa05");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublicId",
                table: "Products",
                newName: "ImageUrl3");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1318c734-00a7-4002-89cd-ef4d3bb91127");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d4d82d7f-14b4-49ae-934e-fa8a850f50a9");
        }
    }
}
