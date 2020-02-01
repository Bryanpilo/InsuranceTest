using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceTest.API.Migrations
{
    public partial class GeneratingInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Clients_ClientId",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_RiskTypes_RiskTypeId",
                table: "Insurances");

            migrationBuilder.AlterColumn<int>(
                name: "RiskTypeId",
                table: "Insurances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Insurances",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Clients_ClientId",
                table: "Insurances",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_RiskTypes_RiskTypeId",
                table: "Insurances",
                column: "RiskTypeId",
                principalTable: "RiskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Clients_ClientId",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_RiskTypes_RiskTypeId",
                table: "Insurances");

            migrationBuilder.AlterColumn<int>(
                name: "RiskTypeId",
                table: "Insurances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Insurances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Clients_ClientId",
                table: "Insurances",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_RiskTypes_RiskTypeId",
                table: "Insurances",
                column: "RiskTypeId",
                principalTable: "RiskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
