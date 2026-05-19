using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class moreentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Direction = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    AccountID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ContactID = table.Column<Guid>(type: "TEXT", nullable: true),
                    OpportunityID = table.Column<Guid>(type: "TEXT", nullable: true),
                    LeadID = table.Column<Guid>(type: "TEXT", nullable: true),
                    OwnerID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ExtraProperties = table.Column<string>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calls_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "CRM",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calls_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalSchema: "CRM",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calls_Leads_LeadID",
                        column: x => x.LeadID,
                        principalSchema: "CRM",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Calls_Opportunities_OpportunityID",
                        column: x => x.OpportunityID,
                        principalSchema: "CRM",
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Subject = table.Column<string>(type: "TEXT", nullable: false),
                    Body = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    From = table.Column<string>(type: "TEXT", nullable: true),
                    To = table.Column<string>(type: "TEXT", nullable: true),
                    Cc = table.Column<string>(type: "TEXT", nullable: true),
                    Bcc = table.Column<string>(type: "TEXT", nullable: true),
                    SentAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsHtml = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccountID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ContactID = table.Column<Guid>(type: "TEXT", nullable: true),
                    OpportunityID = table.Column<Guid>(type: "TEXT", nullable: true),
                    LeadID = table.Column<Guid>(type: "TEXT", nullable: true),
                    OwnerID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ExtraProperties = table.Column<string>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "CRM",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emails_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalSchema: "CRM",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emails_Leads_LeadID",
                        column: x => x.LeadID,
                        principalSchema: "CRM",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emails_Opportunities_OpportunityID",
                        column: x => x.OpportunityID,
                        principalSchema: "CRM",
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    AccountID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ContactID = table.Column<Guid>(type: "TEXT", nullable: true),
                    OpportunityID = table.Column<Guid>(type: "TEXT", nullable: true),
                    LeadID = table.Column<Guid>(type: "TEXT", nullable: true),
                    OwnerID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ExtraProperties = table.Column<string>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meetings_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "CRM",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalSchema: "CRM",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_Leads_LeadID",
                        column: x => x.LeadID,
                        principalSchema: "CRM",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Meetings_Opportunities_OpportunityID",
                        column: x => x.OpportunityID,
                        principalSchema: "CRM",
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AccountID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ContactID = table.Column<Guid>(type: "TEXT", nullable: true),
                    OpportunityID = table.Column<Guid>(type: "TEXT", nullable: true),
                    LeadID = table.Column<Guid>(type: "TEXT", nullable: true),
                    OwnerID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ExtraProperties = table.Column<string>(type: "TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "CRM",
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalSchema: "CRM",
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Leads_LeadID",
                        column: x => x.LeadID,
                        principalSchema: "CRM",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Opportunities_OpportunityID",
                        column: x => x.OpportunityID,
                        principalSchema: "CRM",
                        principalTable: "Opportunities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calls_AccountID",
                table: "Calls",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_ContactID",
                table: "Calls",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_LeadID",
                table: "Calls",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_OpportunityID",
                table: "Calls",
                column: "OpportunityID");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_AccountID",
                table: "Emails",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ContactID",
                table: "Emails",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_LeadID",
                table: "Emails",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_OpportunityID",
                table: "Emails",
                column: "OpportunityID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_AccountID",
                table: "Meetings",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_ContactID",
                table: "Meetings",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_LeadID",
                table: "Meetings",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Meetings_OpportunityID",
                table: "Meetings",
                column: "OpportunityID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AccountID",
                table: "Tasks",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ContactID",
                table: "Tasks",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LeadID",
                table: "Tasks",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OpportunityID",
                table: "Tasks",
                column: "OpportunityID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
