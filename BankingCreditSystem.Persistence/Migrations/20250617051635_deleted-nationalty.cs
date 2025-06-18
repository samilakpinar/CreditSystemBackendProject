using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingCreditSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deletednationalty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IndividualCustomers_Nationality",
                table: "IndividualCustomers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "IndividualCustomers");

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "IndividualCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "IndividualCustomers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "IndividualCustomers");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "IndividualCustomers");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "IndividualCustomers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomers_Nationality",
                table: "IndividualCustomers",
                column: "Nationality",
                unique: true,
                filter: "[Nationality] IS NOT NULL");
        }
    }
}
