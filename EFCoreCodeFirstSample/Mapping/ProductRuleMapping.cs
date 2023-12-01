using EFCoreCodeFirstSample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using MSRulesEngine = global::RulesEngine;

namespace EFCoreCodeFirstSample.Mapping
{
    public class ProductRuleMapping : IProductRuleMapping
    {
        public ProductRuleMapping() { }
        public async Task<List<ProductRule>> GetProductRulesInFileAsync(string filePath)
        {
            List<ProductRule> rules = new List<ProductRule>();
            string fileContent = File.ReadAllText(filePath);
            JsonDocument jsonDocument = JsonDocument.Parse(fileContent);
            if (jsonDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                List<MSRulesEngine.Models.Workflow> rootProductWorkFlows = JsonConvert.DeserializeObject<List<MSRulesEngine.Models.Workflow>>(fileContent);
                foreach (var rootProductWorkFlow in rootProductWorkFlows)
                {
                    var productRule = await MapProductRuleAsync(rootProductWorkFlow);
                    rules.Add(productRule);
                }
            }
            else if (jsonDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                MSRulesEngine.Models.Workflow rootProductWorkFlow = JsonConvert.DeserializeObject<MSRulesEngine.Models.Workflow>(fileContent);
                var productRule = await MapProductRuleAsync(rootProductWorkFlow);
                rules.Add(productRule);
            }
            return rules;
        }
        public async Task<List<ProductRule>> GetDeflatedProductRulesAsync()
        {
            //string licenseRuleFilesPath = Path.Combine(Environment.CurrentDirectory, Constants.licenseRulesPath);
            string productRuleFilesPath = Constants.productRulesPath;
            string[] files = Directory.GetFiles(productRuleFilesPath);
            List<ProductRule> deflatedProductRules = new List<ProductRule>();
            foreach (string file in files)
            {
                List<ProductRule> productRules = new List<ProductRule>();
                productRules = await GetProductRulesInFileAsync(file);
                deflatedProductRules.AddRange(productRules);
            }
            return deflatedProductRules;
        }
        public async Task<ProductRule> MapProductRuleAsync(MSRulesEngine.Models.Workflow rootProductWorkFlow)
        {
            var productRule = new ProductRule();
            productRule.WorkflowName = rootProductWorkFlow.WorkflowName;
            productRule.Rules = rootProductWorkFlow.Rules;
            productRule.GlobalParams = rootProductWorkFlow.GlobalParams;
            return productRule;
        }
    }
}

