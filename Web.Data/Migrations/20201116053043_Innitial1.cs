using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class Innitial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Lock",
                table: "AppUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "Description" },
                values: new object[] { "52d2cda6-b594-4c11-b5a1-2a08fe5f3eb0", "Administrator" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be610e83-55f0-4ddd-8a05-0dc9fac5d9f0", "AQAAAAEAACcQAAAAEP5P7tDkfAAwjDXtQ0fhfqXRH9Lw6QqWwcnUNo1dMeKv86Q2vecaihgbMIk640OKdg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lock",
                table: "AppUsers");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                columns: new[] { "ConcurrencyStamp", "Description" },
                values: new object[] { "4b76e89b-ca83-4719-b391-ded1b50dbf3b", "Administrator role" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "926c98aa-dd3e-440f-8d19-5fdaefde5f1e", "AQAAAAEAACcQAAAAENS4cg8kRWUGOWFjJXZNSaK2Ty1jC3ytfa+B9w8NJfM8Y5MePAUASoQBiPrNANOH3g==" });
        }
    }
}
