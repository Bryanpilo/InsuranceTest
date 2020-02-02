using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceTest.API.Migrations
{
    public partial class UpdatedKeysV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsuranceId",
                table: "RiskTypes");

            migrationBuilder.DropColumn(
                name: "Insurances_InsuranceTypesId",
                table: "InsuranceTypes");

            migrationBuilder.DropColumn(
                name: "Insurances_InsuranceTypesId",
                table: "Insurances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceId",
                table: "RiskTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Insurances_InsuranceTypesId",
                table: "InsuranceTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Insurances_InsuranceTypesId",
                table: "Insurances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
