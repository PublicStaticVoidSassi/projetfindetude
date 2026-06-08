using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class phonenumbersincall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Accounts_AccountID",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Contacts_ContactID",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Leads_LeadID",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Opportunities_OpportunityID",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Accounts_AccountID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Contacts_ContactID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Leads_LeadID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Opportunities_OpportunityID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Accounts_AccountID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Contacts_ContactID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Leads_LeadID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Opportunities_OpportunityID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Accounts_AccountId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Contacts_ContactId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Leads_LeadId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Opportunities_OpportunityId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Accounts_AccountID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Contacts_ContactID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Leads_LeadID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Opportunities_OpportunityID",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Accounts_AccountID",
                table: "Calls",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Contacts_ContactID",
                table: "Calls",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Leads_LeadID",
                table: "Calls",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Opportunities_OpportunityID",
                table: "Calls",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Accounts_AccountID",
                table: "Emails",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Contacts_ContactID",
                table: "Emails",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Leads_LeadID",
                table: "Emails",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Opportunities_OpportunityID",
                table: "Emails",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Accounts_AccountID",
                table: "Meetings",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Contacts_ContactID",
                table: "Meetings",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Leads_LeadID",
                table: "Meetings",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Opportunities_OpportunityID",
                table: "Meetings",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Accounts_AccountId",
                table: "Notes",
                column: "AccountId",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Contacts_ContactId",
                table: "Notes",
                column: "ContactId",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Leads_LeadId",
                table: "Notes",
                column: "LeadId",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Opportunities_OpportunityId",
                table: "Notes",
                column: "OpportunityId",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Accounts_AccountID",
                table: "Tasks",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Contacts_ContactID",
                table: "Tasks",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Leads_LeadID",
                table: "Tasks",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Opportunities_OpportunityID",
                table: "Tasks",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Accounts_AccountID",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Contacts_ContactID",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Leads_LeadID",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Calls_Opportunities_OpportunityID",
                table: "Calls");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Accounts_AccountID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Contacts_ContactID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Leads_LeadID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Opportunities_OpportunityID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Accounts_AccountID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Contacts_ContactID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Leads_LeadID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Meetings_Opportunities_OpportunityID",
                table: "Meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Accounts_AccountId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Contacts_ContactId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Leads_LeadId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Opportunities_OpportunityId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Accounts_AccountID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Contacts_ContactID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Leads_LeadID",
                table: "Tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Opportunities_OpportunityID",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Accounts_AccountID",
                table: "Calls",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Contacts_ContactID",
                table: "Calls",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Leads_LeadID",
                table: "Calls",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calls_Opportunities_OpportunityID",
                table: "Calls",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Accounts_AccountID",
                table: "Emails",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Contacts_ContactID",
                table: "Emails",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Leads_LeadID",
                table: "Emails",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Opportunities_OpportunityID",
                table: "Emails",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Accounts_AccountID",
                table: "Meetings",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Contacts_ContactID",
                table: "Meetings",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Leads_LeadID",
                table: "Meetings",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meetings_Opportunities_OpportunityID",
                table: "Meetings",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Accounts_AccountId",
                table: "Notes",
                column: "AccountId",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Contacts_ContactId",
                table: "Notes",
                column: "ContactId",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Leads_LeadId",
                table: "Notes",
                column: "LeadId",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Opportunities_OpportunityId",
                table: "Notes",
                column: "OpportunityId",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Accounts_AccountID",
                table: "Tasks",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Contacts_ContactID",
                table: "Tasks",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Leads_LeadID",
                table: "Tasks",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Opportunities_OpportunityID",
                table: "Tasks",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
