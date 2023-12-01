using EFCoreCodeFirstSample.Mapping;
using EFCoreCodeFirstSample.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System;
using Newtonsoft.Json;

#nullable disable

namespace EFCoreCodeFirstSample.Migrations
{
    /// <inheritdoc />
    public partial class TryMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LicenseRules2",
                columns: table => new
                {
                    LicenseWorkFlow = table.Column<string>(type: "text", nullable: false),
                    LicenseWorkFlowContent = table.Column<RootLicenseWorkFlow>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseRules2", x => x.LicenseWorkFlow);
                });
            var licenseRules = GetLicenseRules();
            foreach(var licenseRule in licenseRules)
            {
                migrationBuilder.InsertData(
                table: "LicenseRules2",
                columns: new[] { "LicenseWorkFlow", "LicenseWorkFlowContent"},
                columnTypes: new string[] {"string", "string"},
                values: new object[,]
                {
                    { licenseRule.LicenseWorkFlow, JsonConvert.SerializeObject(licenseRule.LicenseWorkFlowContent) },
                });
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LicenseRules");
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
