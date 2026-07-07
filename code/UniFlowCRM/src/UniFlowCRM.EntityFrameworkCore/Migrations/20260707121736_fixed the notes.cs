using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class fixedthenotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "CRM",
                table: "notes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "CRM",
                table: "notes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "CRM",
                table: "notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "CRM",
                table: "notes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "CRM",
                table: "notes",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "CRM",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "CRM",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "CRM",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "CRM",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "CRM",
                table: "notes");
        }
    }
}
