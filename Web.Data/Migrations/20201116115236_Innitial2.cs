using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class Innitial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lock",
                table: "AppUsers");

            migrationBuilder.AddColumn<bool>(
                name: "lockoutOnFailure",
                table: "AppUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "d82d5746-072f-439a-bd94-fc6d14052607");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e05b8609-e1d7-40b6-92f1-c59ab5f1f381", "AQAAAAEAACcQAAAAEAm8ncOPTyJYRrPH/O3U6ciiUsZjez6yf1vL6m0eykqVDMd47I8KMLpYWZMvmKX/Fg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lockoutOnFailure",
                table: "AppUsers");

            migrationBuilder.AddColumn<bool>(
                name: "Lock",
                table: "AppUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "52d2cda6-b594-4c11-b5a1-2a08fe5f3eb0");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be610e83-55f0-4ddd-8a05-0dc9fac5d9f0", "AQAAAAEAACcQAAAAEP5P7tDkfAAwjDXtQ0fhfqXRH9Lw6QqWwcnUNo1dMeKv86Q2vecaihgbMIk640OKdg==" });
        }
    }
}
