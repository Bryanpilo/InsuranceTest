using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceTest.API.Migrations
{
    public partial class SeedingInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Insurances",
                columns: new[] { "Id", "ClientId", "Coverage", "CoverageMonths", "Description", "InitDate", "Name", "Price", "RiskTypeId" },
                values: new object[,]
                {
                    { 1, 1, 30f, 4, "Poliza 1", new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poliza", 1000m, 1 },
                    { 2, 4, 60f, 1, "Poliza 2", new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poliza 2", 2000m, 3 },
                    { 3, 2, 10f, 2, "Poliza 3", new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poliza 3", 5000m, 4 },
                    { 4, 4, 100f, 3, "Poliza 4", new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poliza 4", 10000m, 3 },
                    { 5, 4, 50f, 7, "Poliza 5", new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poliza 5", 2000m, 4 },
                    { 6, 2, 25f, 9, "Poliza 6", new DateTime(2017, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poliza 6", 5000m, 3 }
                });

            migrationBuilder.InsertData(
                table: "Insurances_InsuranceTypes",
                columns: new[] { "Id", "InsuranceId", "InsuranceTypeId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 1 },
                    { 3, 2, 3 },
                    { 4, 3, 4 },
                    { 5, 3, 1 },
                    { 6, 3, 2 },
                    { 7, 4, 2 },
                    { 8, 4, 1 },
                    { 9, 5, 1 },
                    { 10, 5, 2 },
                    { 11, 5, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Insurances_InsuranceTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Insurances",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
