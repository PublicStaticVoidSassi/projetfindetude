using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class fixedcampaigns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                schema: "CRM",
                table: "Campaigns",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                schema: "CRM",
                table: "Campaigns",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                schema: "CRM",
                table: "Campaigns",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                schema: "CRM",
                table: "Campaigns",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "CRM",
                table: "Campaigns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                schema: "CRM",
                table: "Campaigns",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                schema: "CRM",
                table: "Campaigns",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                schema: "CRM",
                table: "Campaigns");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                schema: "CRM",
                table: "Campaigns");
        }
    }
}
