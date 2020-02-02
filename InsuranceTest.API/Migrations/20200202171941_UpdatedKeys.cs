using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceTest.API.Migrations
{
    public partial class UpdatedKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceId",
                table: "RiskTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Insurances_InsuranceTypesId",
                table: "InsuranceTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Insurances_InsuranceTypesId",
                table: "Insurances",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
