using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceTest.API.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "admin123");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 48, 120, 56, 49, 70, 68, 53, 51, 54, 68, 51, 70, 49, 51, 56, 54, 55, 51, 48, 52, 66, 70, 48, 65, 68, 67, 66, 49, 48, 66, 51, 67, 52, 52, 55, 49, 51, 51, 53, 51, 52, 68, 67, 67, 57, 54, 52, 55, 53, 50, 48, 51, 69, 51, 49, 57, 52, 55, 53, 68, 66, 66, 54, 55, 51, 55, 68, 69, 69, 50, 48, 51, 48, 49, 67, 48, 69, 57, 50, 49, 69, 69, 48, 53, 52, 51, 54, 66, 67, 69, 70, 55, 53, 68, 48, 51, 50, 50, 52, 57, 50, 52, 50, 69, 65, 49, 50, 52, 51, 69, 55, 54, 53, 56, 49, 68, 57, 69, 51, 52, 52, 52, 49, 68, 52, 52, 55, 69, 49, 51, 48, 120, 56, 49, 70, 68, 53, 51, 54, 68, 51, 70, 49, 51, 56, 54, 55, 51, 48, 52, 66, 70, 48, 65, 68, 67, 66, 49, 48, 66, 51, 67, 52, 52, 55, 49, 51, 51, 53, 51, 52, 68, 67, 67, 57, 54, 52, 55, 53, 50, 48, 51, 69, 51, 49, 57, 52, 55, 53, 68, 66, 66, 54, 55, 51, 55, 68, 69, 69, 50, 48, 51, 48, 49, 67, 48, 69, 57, 50, 49, 69, 69, 48, 53, 52, 51, 54, 66, 67, 69, 70, 55, 53, 68, 48, 51, 50, 50, 52, 57, 50, 52, 50, 69, 65, 49, 50, 52, 51, 69, 55, 54, 53, 56, 49, 68, 57, 69, 51, 52, 52, 52, 49, 68, 52, 52, 55, 69, 49, 51 }, new byte[] { 48, 120, 69, 51, 68, 70, 49, 49, 65, 49, 55, 57, 68, 69, 68, 48, 52, 49, 52, 65, 67, 49, 52, 69, 67, 49, 66, 53, 53, 50, 67, 70, 49, 51, 55, 65, 53, 69, 55, 56, 57, 70, 65, 51, 56, 69, 48, 50, 56, 53, 68, 69, 51, 54, 57, 67, 51, 48, 49, 68, 66, 49, 65, 54, 56, 67, 49, 65, 66, 54, 54, 57, 49, 50, 53, 66, 51, 50, 49, 54, 57, 66, 68, 67, 68, 67, 67, 49, 57, 51, 67, 55, 56, 65, 52, 69, 67, 69, 66, 65, 53, 66, 70, 50, 65, 49, 66, 67, 56, 70, 49, 52, 70, 51, 68, 69, 68, 49, 52, 65, 67, 51, 54, 51, 66, 51, 53, 48, 69, 49, 65, 65, 66, 52, 48, 66, 67, 70, 66, 52, 68, 55, 50, 67, 49, 56, 54, 68, 51, 51, 68, 65, 53, 68, 53, 49, 50, 66, 48, 55, 50, 48, 66, 49, 57, 68, 56, 51, 54, 54, 69, 69, 68, 48, 56, 50, 52, 50, 51, 52, 65, 57, 55, 50, 69, 53, 56, 48, 51, 52, 67, 54, 65, 67, 69, 51, 67, 54, 51, 50, 51, 54, 67, 48, 49, 50, 67, 50, 69, 67, 57, 48, 49, 57, 65, 50, 57, 49, 51, 52, 57, 65, 51, 48, 53, 55, 67, 55, 65, 54, 55, 69, 48, 57, 66, 56, 68, 65, 70, 49, 66, 52, 48, 66, 51, 57, 54, 48, 50, 55, 48, 70, 51, 51, 57, 55, 54, 56 } });
        }
    }
}
