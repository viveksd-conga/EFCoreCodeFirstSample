using EFCoreCodeFirstSample.Mapping;
using EFCoreCodeFirstSample.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System;

#nullable disable

namespace EFCoreCodeFirstSample.Migrations.LicenseMigration
{
    /// <inheritdoc />
    public partial class ProductRuleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var productRules = GetProductRules();
            foreach (var productRule in productRules)
            {
                migrationBuilder.InsertData(
                    table: "ProductRules",
                    columns: new[] { "WorkflowName", "GlobalParams", "Rules" },
                    columnTypes: new string[] { "string", "json", "json" },
                    values: new object[,]
                    {
                        {
                            productRule.WorkflowName,
                            productRule.GlobalParams,
                            productRule.Rules
                        },
                    }
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductRules");
        }
        private static List<ProductRule> GetProductRules()
        {
            IProductRuleMapping productRuleMapping = new ProductRuleMapping();
            List<ProductRule> productRules = productRuleMapping.GetDeflatedProductRulesAsync().Result;
            if (productRules.Count == 0)
            {
                throw new Exception("Couldn't find any Product Rules.");
            }
            return productRules;
        }
    }
}
