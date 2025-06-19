using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingCreditSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualTurnover",
                table: "CorporateCustomers");

            migrationBuilder.RenameColumn(
                name: "LegalStatus",
                table: "CorporateCustomers",
                newName: "TaxOffice");

            migrationBuilder.RenameColumn(
                name: "EstablishmentDate",
                table: "CorporateCustomers",
                newName: "CompanyFoundationDate");

            migrationBuilder.AddColumn<string>(
                name: "AuthorizedPersonName",
                table: "CorporateCustomers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorizedPersonName",
                table: "CorporateCustomers");

            migrationBuilder.RenameColumn(
                name: "TaxOffice",
                table: "CorporateCustomers",
                newName: "LegalStatus");

            migrationBuilder.RenameColumn(
                name: "CompanyFoundationDate",
                table: "CorporateCustomers",
                newName: "EstablishmentDate");

            migrationBuilder.AddColumn<decimal>(
                name: "AnnualTurnover",
                table: "CorporateCustomers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
