using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Data.Migrations
{
    public partial class Innitial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Lock",
                table: "AppUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "dc53c939-7ded-4c08-a6d2-1e00d0995039");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50291785-25dd-42a8-8ed5-757e826c6b08", "AQAAAAEAACcQAAAAEA4oP0i1UAQWO/mr80OOli9tVseuU3fvxYhYdCQE3SP9nh7RoYKgp2Kg+Tel0LBgog==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lock",
                table: "AppUsers");

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
    }
}
