using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreCodeFirstSample.Migrations.LicenseMigration
{
    /// <inheritdoc />
    public partial class NewProductWorkFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductWorkFlow",
                table: "ProductRules",
                newName: "WorkflowName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WorkflowName",
                table: "ProductRules",
                newName: "ProductWorkFlow");
        }
    }
}
