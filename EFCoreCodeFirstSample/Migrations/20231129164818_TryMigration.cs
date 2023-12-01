using System;
using EFCoreCodeFirstSample.Mapping;
using System.Collections.Generic;
using EFCoreCodeFirstSample.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreCodeFirstSample.Migrations
{
    /// <inheritdoc />
    public partial class TryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employees",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CustomersMetaData",
                columns: table => new
                {
                    CustId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<string>(type: "text", nullable: true),
                    OrganizationFriendlyId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomersMetaData", x => x.CustId);
                });

            migrationBuilder.CreateTable(
                name: "LicenseRules",
                columns: table => new
                {
                    LicenseWorkFlow = table.Column<string>(type: "text", nullable: false),
                    LicenseWorkFlowContent = table.Column<RootLicenseWorkFlow>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseRules", x => x.LicenseWorkFlow);
                });

            migrationBuilder.InsertData(
                table: "CustomersMetaData",
                columns: new[] { "CustId", "OrganizationFriendlyId", "OrganizationId" },
                values: new object[,]
                {
                    { 103L, "123xyz", "xyz123" },
                    { 104L, "123321xyz", "xyz123321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomersMetaData");

            migrationBuilder.DropTable(
                name: "LicenseRules");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
        private static List<LicenseRule> GetLicenseRules()
        {
            ILicenseRuleMapping licenseRuleMapping = new LicenseRuleMapping();
            List<LicenseRule> licenseRules = licenseRuleMapping.GetDeflatedLicenseRulesAsync().Result;
            if (licenseRules.Count == 0)
            {
                throw new Exception("Couldn't find any License Rules.");
            }
            return licenseRules;
        }
    }
}
