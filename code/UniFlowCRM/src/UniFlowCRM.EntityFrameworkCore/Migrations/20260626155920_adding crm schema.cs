using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class addingcrmschema : Migration
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

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calls",
                table: "Calls");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "tasks",
                newSchema: "CRM");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "notes",
                newSchema: "CRM");

            migrationBuilder.RenameTable(
                name: "Meetings",
                newName: "meetings",
                newSchema: "CRM");

            migrationBuilder.RenameTable(
                name: "Emails",
                newName: "emails",
                newSchema: "CRM");

            migrationBuilder.RenameTable(
                name: "Calls",
                newName: "calls",
                newSchema: "CRM");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_OpportunityID",
                schema: "CRM",
                table: "tasks",
                newName: "IX_tasks_OpportunityID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_LeadID",
                schema: "CRM",
                table: "tasks",
                newName: "IX_tasks_LeadID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ContactID",
                schema: "CRM",
                table: "tasks",
                newName: "IX_tasks_ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_AccountID",
                schema: "CRM",
                table: "tasks",
                newName: "IX_tasks_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_OpportunityId",
                schema: "CRM",
                table: "notes",
                newName: "IX_notes_OpportunityId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_LeadId",
                schema: "CRM",
                table: "notes",
                newName: "IX_notes_LeadId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_ContactId",
                schema: "CRM",
                table: "notes",
                newName: "IX_notes_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_AccountId",
                schema: "CRM",
                table: "notes",
                newName: "IX_notes_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_OpportunityID",
                schema: "CRM",
                table: "meetings",
                newName: "IX_meetings_OpportunityID");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_LeadID",
                schema: "CRM",
                table: "meetings",
                newName: "IX_meetings_LeadID");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_ContactID",
                schema: "CRM",
                table: "meetings",
                newName: "IX_meetings_ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_Meetings_AccountID",
                schema: "CRM",
                table: "meetings",
                newName: "IX_meetings_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_OpportunityID",
                schema: "CRM",
                table: "emails",
                newName: "IX_emails_OpportunityID");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_LeadID",
                schema: "CRM",
                table: "emails",
                newName: "IX_emails_LeadID");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_ContactID",
                schema: "CRM",
                table: "emails",
                newName: "IX_emails_ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_AccountID",
                schema: "CRM",
                table: "emails",
                newName: "IX_emails_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_Calls_OpportunityID",
                schema: "CRM",
                table: "calls",
                newName: "IX_calls_OpportunityID");

            migrationBuilder.RenameIndex(
                name: "IX_Calls_LeadID",
                schema: "CRM",
                table: "calls",
                newName: "IX_calls_LeadID");

            migrationBuilder.RenameIndex(
                name: "IX_Calls_ContactID",
                schema: "CRM",
                table: "calls",
                newName: "IX_calls_ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_Calls_AccountID",
                schema: "CRM",
                table: "calls",
                newName: "IX_calls_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tasks",
                schema: "CRM",
                table: "tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_notes",
                schema: "CRM",
                table: "notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_meetings",
                schema: "CRM",
                table: "meetings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_emails",
                schema: "CRM",
                table: "emails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_calls",
                schema: "CRM",
                table: "calls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_calls_Accounts_AccountID",
                schema: "CRM",
                table: "calls",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_calls_Contacts_ContactID",
                schema: "CRM",
                table: "calls",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_calls_Leads_LeadID",
                schema: "CRM",
                table: "calls",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_calls_Opportunities_OpportunityID",
                schema: "CRM",
                table: "calls",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_emails_Accounts_AccountID",
                schema: "CRM",
                table: "emails",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_emails_Contacts_ContactID",
                schema: "CRM",
                table: "emails",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_emails_Leads_LeadID",
                schema: "CRM",
                table: "emails",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_emails_Opportunities_OpportunityID",
                schema: "CRM",
                table: "emails",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_meetings_Accounts_AccountID",
                schema: "CRM",
                table: "meetings",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_meetings_Contacts_ContactID",
                schema: "CRM",
                table: "meetings",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_meetings_Leads_LeadID",
                schema: "CRM",
                table: "meetings",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_meetings_Opportunities_OpportunityID",
                schema: "CRM",
                table: "meetings",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_Accounts_AccountId",
                schema: "CRM",
                table: "notes",
                column: "AccountId",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_Contacts_ContactId",
                schema: "CRM",
                table: "notes",
                column: "ContactId",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_Leads_LeadId",
                schema: "CRM",
                table: "notes",
                column: "LeadId",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_Opportunities_OpportunityId",
                schema: "CRM",
                table: "notes",
                column: "OpportunityId",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Accounts_AccountID",
                schema: "CRM",
                table: "tasks",
                column: "AccountID",
                principalSchema: "CRM",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Contacts_ContactID",
                schema: "CRM",
                table: "tasks",
                column: "ContactID",
                principalSchema: "CRM",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Leads_LeadID",
                schema: "CRM",
                table: "tasks",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_Opportunities_OpportunityID",
                schema: "CRM",
                table: "tasks",
                column: "OpportunityID",
                principalSchema: "CRM",
                principalTable: "Opportunities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_calls_Accounts_AccountID",
                schema: "CRM",
                table: "calls");

            migrationBuilder.DropForeignKey(
                name: "FK_calls_Contacts_ContactID",
                schema: "CRM",
                table: "calls");

            migrationBuilder.DropForeignKey(
                name: "FK_calls_Leads_LeadID",
                schema: "CRM",
                table: "calls");

            migrationBuilder.DropForeignKey(
                name: "FK_calls_Opportunities_OpportunityID",
                schema: "CRM",
                table: "calls");

            migrationBuilder.DropForeignKey(
                name: "FK_emails_Accounts_AccountID",
                schema: "CRM",
                table: "emails");

            migrationBuilder.DropForeignKey(
                name: "FK_emails_Contacts_ContactID",
                schema: "CRM",
                table: "emails");

            migrationBuilder.DropForeignKey(
                name: "FK_emails_Leads_LeadID",
                schema: "CRM",
                table: "emails");

            migrationBuilder.DropForeignKey(
                name: "FK_emails_Opportunities_OpportunityID",
                schema: "CRM",
                table: "emails");

            migrationBuilder.DropForeignKey(
                name: "FK_meetings_Accounts_AccountID",
                schema: "CRM",
                table: "meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_meetings_Contacts_ContactID",
                schema: "CRM",
                table: "meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_meetings_Leads_LeadID",
                schema: "CRM",
                table: "meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_meetings_Opportunities_OpportunityID",
                schema: "CRM",
                table: "meetings");

            migrationBuilder.DropForeignKey(
                name: "FK_notes_Accounts_AccountId",
                schema: "CRM",
                table: "notes");

            migrationBuilder.DropForeignKey(
                name: "FK_notes_Contacts_ContactId",
                schema: "CRM",
                table: "notes");

            migrationBuilder.DropForeignKey(
                name: "FK_notes_Leads_LeadId",
                schema: "CRM",
                table: "notes");

            migrationBuilder.DropForeignKey(
                name: "FK_notes_Opportunities_OpportunityId",
                schema: "CRM",
                table: "notes");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Accounts_AccountID",
                schema: "CRM",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Contacts_ContactID",
                schema: "CRM",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Leads_LeadID",
                schema: "CRM",
                table: "tasks");

            migrationBuilder.DropForeignKey(
                name: "FK_tasks_Opportunities_OpportunityID",
                schema: "CRM",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tasks",
                schema: "CRM",
                table: "tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_notes",
                schema: "CRM",
                table: "notes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_meetings",
                schema: "CRM",
                table: "meetings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emails",
                schema: "CRM",
                table: "emails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_calls",
                schema: "CRM",
                table: "calls");

            migrationBuilder.RenameTable(
                name: "tasks",
                schema: "CRM",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "notes",
                schema: "CRM",
                newName: "Notes");

            migrationBuilder.RenameTable(
                name: "meetings",
                schema: "CRM",
                newName: "Meetings");

            migrationBuilder.RenameTable(
                name: "emails",
                schema: "CRM",
                newName: "Emails");

            migrationBuilder.RenameTable(
                name: "calls",
                schema: "CRM",
                newName: "Calls");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_OpportunityID",
                table: "Tasks",
                newName: "IX_Tasks_OpportunityID");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_LeadID",
                table: "Tasks",
                newName: "IX_Tasks_LeadID");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_ContactID",
                table: "Tasks",
                newName: "IX_Tasks_ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_tasks_AccountID",
                table: "Tasks",
                newName: "IX_Tasks_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_notes_OpportunityId",
                table: "Notes",
                newName: "IX_Notes_OpportunityId");

            migrationBuilder.RenameIndex(
                name: "IX_notes_LeadId",
                table: "Notes",
                newName: "IX_Notes_LeadId");

            migrationBuilder.RenameIndex(
                name: "IX_notes_ContactId",
                table: "Notes",
                newName: "IX_Notes_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_notes_AccountId",
                table: "Notes",
                newName: "IX_Notes_AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_meetings_OpportunityID",
                table: "Meetings",
                newName: "IX_Meetings_OpportunityID");

            migrationBuilder.RenameIndex(
                name: "IX_meetings_LeadID",
                table: "Meetings",
                newName: "IX_Meetings_LeadID");

            migrationBuilder.RenameIndex(
                name: "IX_meetings_ContactID",
                table: "Meetings",
                newName: "IX_Meetings_ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_meetings_AccountID",
                table: "Meetings",
                newName: "IX_Meetings_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_emails_OpportunityID",
                table: "Emails",
                newName: "IX_Emails_OpportunityID");

            migrationBuilder.RenameIndex(
                name: "IX_emails_LeadID",
                table: "Emails",
                newName: "IX_Emails_LeadID");

            migrationBuilder.RenameIndex(
                name: "IX_emails_ContactID",
                table: "Emails",
                newName: "IX_Emails_ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_emails_AccountID",
                table: "Emails",
                newName: "IX_Emails_AccountID");

            migrationBuilder.RenameIndex(
                name: "IX_calls_OpportunityID",
                table: "Calls",
                newName: "IX_Calls_OpportunityID");

            migrationBuilder.RenameIndex(
                name: "IX_calls_LeadID",
                table: "Calls",
                newName: "IX_Calls_LeadID");

            migrationBuilder.RenameIndex(
                name: "IX_calls_ContactID",
                table: "Calls",
                newName: "IX_Calls_ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_calls_AccountID",
                table: "Calls",
                newName: "IX_Calls_AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meetings",
                table: "Meetings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calls",
                table: "Calls",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

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
    }
}
