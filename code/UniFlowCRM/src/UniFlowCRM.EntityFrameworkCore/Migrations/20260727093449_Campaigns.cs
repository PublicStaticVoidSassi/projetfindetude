using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class Campaigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                schema: "CRM",
                table: "Opportunities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                schema: "CRM",
                table: "Leads",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                schema: "CRM",
                table: "Contacts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                schema: "CRM",
                table: "Accounts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Campaigns",
                schema: "CRM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaigns_AbpUsers_AssignedTo",
                        column: x => x.AssignedTo,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_CampaignId",
                schema: "CRM",
                table: "Opportunities",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CampaignId",
                schema: "CRM",
                table: "Leads",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CampaignId",
                schema: "CRM",
                table: "Contacts",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CampaignId",
                schema: "CRM",
                table: "Accounts",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_AssignedTo",
                schema: "CRM",
                table: "Campaigns",
                column: "AssignedTo");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Campaigns_CampaignId",
                schema: "CRM",
                table: "Accounts",
                column: "CampaignId",
                principalSchema: "CRM",
                principalTable: "Campaigns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Campaigns_CampaignId",
                schema: "CRM",
                table: "Contacts",
                column: "CampaignId",
                principalSchema: "CRM",
                principalTable: "Campaigns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Campaigns_CampaignId",
                schema: "CRM",
                table: "Leads",
                column: "CampaignId",
                principalSchema: "CRM",
                principalTable: "Campaigns",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Opportunities_Campaigns_CampaignId",
                schema: "CRM",
                table: "Opportunities",
                column: "CampaignId",
                principalSchema: "CRM",
                principalTable: "Campaigns",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Campaigns_CampaignId",
                schema: "CRM",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Campaigns_CampaignId",
                schema: "CRM",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Campaigns_CampaignId",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Opportunities_Campaigns_CampaignId",
                schema: "CRM",
                table: "Opportunities");

            migrationBuilder.DropTable(
                name: "Campaigns",
                schema: "CRM");

            migrationBuilder.DropIndex(
                name: "IX_Opportunities_CampaignId",
                schema: "CRM",
                table: "Opportunities");

            migrationBuilder.DropIndex(
                name: "IX_Leads_CampaignId",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CampaignId",
                schema: "CRM",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CampaignId",
                schema: "CRM",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                schema: "CRM",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                schema: "CRM",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                schema: "CRM",
                table: "Accounts");
        }
    }
}
