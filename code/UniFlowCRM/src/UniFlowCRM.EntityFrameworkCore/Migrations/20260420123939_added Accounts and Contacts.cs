using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class addedAccountsandContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AccountID",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                schema: "CRM",
                table: "Leads",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Accounts",
                schema: "CRM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Fax = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<int>(type: "INTEGER", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Industry = table.Column<int>(type: "INTEGER", nullable: false),
                    IncomeValue = table.Column<decimal>(type: "TEXT", nullable: true),
                    IncomeCurrency = table.Column<int>(type: "INTEGER", nullable: true),
                    Employees = table.Column<int>(type: "INTEGER", nullable: true),
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_AbpUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                schema: "CRM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Source = table.Column<int>(type: "INTEGER", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Fax = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<int>(type: "INTEGER", nullable: true),
                    Job = table.Column<string>(type: "TEXT", nullable: true),
                    Departement = table.Column<string>(type: "TEXT", nullable: true),
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountID = table.Column<Guid>(type: "TEXT", nullable: true),
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
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AbpUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalSchema: "CRM",
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_AccountID",
                schema: "CRM",
                table: "Leads",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_UserID",
                schema: "CRM",
                table: "Leads",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserID",
                schema: "CRM",
                table: "Accounts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AccountID",
                schema: "CRM",
                table: "Contacts",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserID",
                schema: "CRM",
                table: "Contacts",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_AbpUsers_UserID",
                schema: "CRM",
                table: "Leads",
                column: "UserID",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Leads_AbpUsers_UserID",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Accounts_AccountID",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropTable(
                name: "Contacts",
                schema: "CRM");

            migrationBuilder.DropTable(
                name: "Accounts",
                schema: "CRM");

            migrationBuilder.DropIndex(
                name: "IX_Leads_AccountID",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropIndex(
                name: "IX_Leads_UserID",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "AccountID",
                schema: "CRM",
                table: "Leads");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "CRM",
                table: "Leads");
        }
    }
}
