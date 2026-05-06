using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniFlowCRM.Migrations
{
    /// <inheritdoc />
    public partial class morestufff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Departement",
                schema: "CRM",
                table: "Contacts",
                newName: "LeadID");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "CRM",
                table: "Contacts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                schema: "CRM",
                table: "Contacts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_LeadID",
                schema: "CRM",
                table: "Contacts",
                column: "LeadID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Leads_LeadID",
                schema: "CRM",
                table: "Contacts",
                column: "LeadID",
                principalSchema: "CRM",
                principalTable: "Leads",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Leads_LeadID",
                schema: "CRM",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_LeadID",
                schema: "CRM",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Department",
                schema: "CRM",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "LeadID",
                schema: "CRM",
                table: "Contacts",
                newName: "Departement");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "CRM",
                table: "Contacts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
