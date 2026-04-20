using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class addedlead : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AppBooks",
                table: "AppBooks");

            migrationBuilder.EnsureSchema(
                name: "CRM");

            migrationBuilder.RenameTable(
                name: "AppBooks",
                newName: "Books",
                newSchema: "CRM");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                schema: "CRM",
                table: "Books",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Leads",
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
                    table.PrimaryKey("PK_Leads", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads",
                schema: "CRM");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                schema: "CRM",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                schema: "CRM",
                newName: "AppBooks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppBooks",
                table: "AppBooks",
                column: "Id");
        }
    }
}
