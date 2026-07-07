using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class stablestuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Accounts_AccountID",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Accounts_AccountID",
                schema: "CRM",
                table: "Leads",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Accounts_AccountID",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Accounts_AccountID",
                schema: "CRM",
                table: "Leads",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
