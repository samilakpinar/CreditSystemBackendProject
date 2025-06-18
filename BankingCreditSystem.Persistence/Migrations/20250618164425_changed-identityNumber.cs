using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingCreditSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changedidentityNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdentityNumber",
                table: "IndividualCustomers",
                newName: "NationalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalId",
                table: "IndividualCustomers",
                newName: "IdentityNumber");
        }
    }
}
