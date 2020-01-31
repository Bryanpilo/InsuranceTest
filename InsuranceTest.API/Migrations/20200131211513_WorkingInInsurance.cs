using Microsoft.EntityFrameworkCore.Migrations;

namespace InsuranceTest.API.Migrations
{
    public partial class WorkingInInsurance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_InsuranceTypes_InsuranceTypeId",
                table: "Insurances");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_InsuranceTypeId",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "InsuranceTypeId",
                table: "Insurances");

            migrationBuilder.CreateTable(
                name: "Insurances_InsuranceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceId = table.Column<int>(nullable: false),
                    InsuranceTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances_InsuranceTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurances_InsuranceTypes_Insurances_InsuranceId",
                        column: x => x.InsuranceId,
                        principalTable: "Insurances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Insurances_InsuranceTypes_InsuranceTypes_InsuranceTypeId",
                        column: x => x.InsuranceTypeId,
                        principalTable: "InsuranceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_InsuranceTypes_InsuranceId",
                table: "Insurances_InsuranceTypes",
                column: "InsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_InsuranceTypes_InsuranceTypeId",
                table: "Insurances_InsuranceTypes",
                column: "InsuranceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Insurances_InsuranceTypes");

            migrationBuilder.AddColumn<int>(
                name: "InsuranceTypeId",
                table: "Insurances",
                type: "int",
                nullable: true);

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
    }
}
