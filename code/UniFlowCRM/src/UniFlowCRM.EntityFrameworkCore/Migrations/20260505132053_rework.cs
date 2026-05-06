using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class rework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Country",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Departement",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Fax",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Job",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "Website",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Opportunities",
                schema: "CRM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AmountValue = table.Column<decimal>(type: "TEXT", nullable: false),
                    AmountCurrency = table.Column<int>(type: "INTEGER", nullable: false),
                    Stage = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    SaleStage = table.Column<int>(type: "INTEGER", nullable: false),
                    Probability = table.Column<short>(type: "INTEGER", nullable: false),
                    NextStep = table.Column<string>(type: "TEXT", nullable: true),
                    ClosedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    LeadID = table.Column<Guid>(type: "TEXT", nullable: true),
                    AccountID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ContactID = table.Column<Guid>(type: "TEXT", nullable: true),
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
                    table.PrimaryKey("PK_Opportunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunities_AbpUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Opportunities_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "CRM",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opportunities_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalSchema: "CRM",
                        principalTable: "Contacts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opportunities_Leads_LeadID",
                        column: x => x.LeadID,
                        principalSchema: "CRM",
                        principalTable: "Leads",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_AccountID",
                schema: "CRM",
                table: "Opportunities",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_ContactID",
                schema: "CRM",
                table: "Opportunities",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_LeadID",
                schema: "CRM",
                table: "Opportunities",
                column: "LeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunities_UserID",
                schema: "CRM",
                table: "Opportunities",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opportunities",
                schema: "CRM");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departement",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                schema: "CRM",
                table: "Leads",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true);
        }
    }
}
