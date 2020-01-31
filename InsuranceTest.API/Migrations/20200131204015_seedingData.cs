using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceTest.API.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceTypes_Insurances_InsuranceId",
                table: "InsuranceTypes");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceTypes_InsuranceId",
                table: "InsuranceTypes");

            migrationBuilder.DropColumn(
                name: "Coverage",
                table: "InsuranceTypes");

            migrationBuilder.DropColumn(
                name: "InsuranceId",
                table: "InsuranceTypes");

            migrationBuilder.DropColumn(
                name: "Change",
                table: "Clients");

            migrationBuilder.AddColumn<float>(
                name: "Coverage",
                table: "Insurances",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "InsuranceTypeId",
                table: "Insurances",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Charge",
                table: "Clients",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Charge", "FullName", "InitDate", "Salary" },
                values: new object[,]
                {
                    { 1, "Software developer", "Bryan Espinoza López", new DateTime(2017, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { 2, "Project Manager", "Josue Jara Sanchez", new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000m },
                    { 3, "Software developer", "Denia Barboza Grajal", new DateTime(2020, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000m },
                    { 4, "Assistan Manager", "Ivannia Lacayo Varquero", new DateTime(2015, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500m }
                });

            migrationBuilder.InsertData(
                table: "InsuranceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Terremoto" },
                    { 2, "Incendio" },
                    { 3, "Robo" },
                    { 4, "Pérdida" }
                });

            migrationBuilder.InsertData(
                table: "RiskTypes",
                columns: new[] { "Id", "Risk" },
                values: new object[,]
                {
                    { 1, "Bajo" },
                    { 2, "Medio" },
                    { 3, "Medio-alto" },
                    { 4, "Alto" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_InsuranceTypeId",
                table: "Insurances",
                column: "InsuranceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_InsuranceTypes_InsuranceTypeId",
                table: "Insurances",
                column: "InsuranceTypeId",
                principalTable: "InsuranceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_InsuranceTypes_InsuranceTypeId",
                table: "Insurances");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_InsuranceTypeId",
                table: "Insurances");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InsuranceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InsuranceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InsuranceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InsuranceTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RiskTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RiskTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RiskTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RiskTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Coverage",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "InsuranceTypeId",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "Charge",
                table: "Clients");

            migrationBuilder.AddColumn<float>(
                name: "Coverage",
                table: "InsuranceTypes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "InsuranceId",
                table: "InsuranceTypes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Change",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTypes_InsuranceId",
                table: "InsuranceTypes",
                column: "InsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceTypes_Insurances_InsuranceId",
                table: "InsuranceTypes",
                column: "InsuranceId",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
