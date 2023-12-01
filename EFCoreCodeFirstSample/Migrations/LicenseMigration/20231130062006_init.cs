using System;
using System.Collections.Generic;
using EFCoreCodeFirstSample.AWS;
using EFCoreCodeFirstSample.Mapping;
using EFCoreCodeFirstSample.Mapping.S3Model;
using EFCoreCodeFirstSample.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json;
using RulesEngine.Models;
using License = EFCoreCodeFirstSample.Models.License;

#nullable disable

namespace EFCoreCodeFirstSample.Migrations.LicenseMigration
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            var licenseRules = GetLicenseRules();
            foreach(var licenseRule in licenseRules)
            {
                migrationBuilder.InsertData(
                table: "LicenseRules",
                columns: new[] { "LicenseWorkFlow", "LicenseWorkFlowContent" },
                columnTypes: new string[] { "string", "string" },
                values: new object[,]
                {
                    { licenseRule.LicenseWorkFlow, JsonConvert.SerializeObject(licenseRule.LicenseWorkFlowContent) },
                });
            }

            migrationBuilder.CreateTable(
                name: "Licenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationFriendlyId = table.Column<string>(type: "text", nullable: true),
                    LicenseName = table.Column<string>(type: "text", nullable: true),
                    LicenseType = table.Column<string>(type: "text", nullable: true),
                    LicenseStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LicenseExpiryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    AccountName = table.Column<string>(type: "text", nullable: true),
                    AccountId = table.Column<string>(type: "text", nullable: true),
                    InForce = table.Column<bool>(type: "boolean", nullable: false),
                    Attributes = table.Column<Dictionary<string, object>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licenses", x => x.Id);
                });

            var licenses = GetLicenses();
            foreach(var license in licenses)
            {
                migrationBuilder.InsertData(
                    table: "Licenses",
                    columns: new[] { "Id", "OrganizationFriendlyId", "LicenseName", "LicenseType", "LicenseStartDate", "LicenseExpiryDate",
                    "AccountName", "AccountId", "InForce", "Attributes" },
                    columnTypes: new string[] { "string", "string", "string", "string", "date", "date", "string", "string", "bool", "json" },
                    values: new object[,]
                    {
                        { 
                            license.Id, 
                            license.OrganizationFriendlyId,
                            license.LicenseName,
                            license.LicenseType,
                            license.LicenseStartDate,
                            license.LicenseExpiryDate,
                            license.AccountName,
                            license.AccountId,
                            license.InForce,
                            license.Attributes
                        },
                    });
            }

            migrationBuilder.CreateTable(
                name: "ProductRules",
                columns: table => new
                {
                    WorkflowName = table.Column<string>(type: "text", nullable: false),
                    GlobalParams = table.Column<IEnumerable<ScopedParam>>(type: "jsonb", nullable: true),
                    Rules = table.Column<IEnumerable<Rule>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRules", x => x.WorkflowName);
                });
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseRules");

            migrationBuilder.DropTable(
                name: "Licenses");

            migrationBuilder.DropTable(
                name: "ProductRules");
        }

        private static List<EFCoreCodeFirstSample.Models.License> GetLicenses()
        {
            ILocalTenantOnboarding localTenantOnboarding = new LocalTenantOnboarding();
            License_S3 license_S3 = new License_S3(localTenantOnboarding);
            List<EFCoreCodeFirstSample.Models.License> licenses = license_S3.GetLicensesAsync().Result;
            if (licenses.Count == 0)
            {
                throw new Exception("Couldn't find any licenses");
            }
            return licenses;
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
