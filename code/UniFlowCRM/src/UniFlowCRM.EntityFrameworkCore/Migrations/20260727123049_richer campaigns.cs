using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class richercampaigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BudgetCurrency",
                schema: "CRM",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "BudgetValue",
                schema: "CRM",
                table: "Campaigns",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "CostCurrency",
                schema: "CRM",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "CostValue",
                schema: "CRM",
                table: "Campaigns",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedAccounts",
                schema: "CRM",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedContacts",
                schema: "CRM",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedLeads",
                schema: "CRM",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedOpportunities",
                schema: "CRM",
                table: "Campaigns",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetCurrency",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "BudgetValue",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CostCurrency",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CostValue",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "ExpectedAccounts",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "ExpectedContacts",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "ExpectedLeads",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "ExpectedOpportunities",
                schema: "CRM",
                table: "Campaigns");
        }
    }
}
