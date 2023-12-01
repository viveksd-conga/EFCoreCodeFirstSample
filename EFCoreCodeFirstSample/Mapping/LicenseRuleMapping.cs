using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EFCoreCodeFirstSample.Models;
using Newtonsoft.Json;


namespace EFCoreCodeFirstSample.Mapping
{
    public class LicenseRuleMapping : ILicenseRuleMapping
    {
        public LicenseRuleMapping() 
        { 
        }
        public async Task<List<LicenseRule>> GetLicenseRulesInFileAsync(string filePath)
        {
            List<LicenseRule> rules = new List<LicenseRule>();
            string fileContent = File.ReadAllText(filePath);
            JsonDocument jsonDocument = JsonDocument.Parse(fileContent);
            if(jsonDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                List<RootLicenseWorkFlow> rootLicenseWorkFlows = JsonConvert.DeserializeObject<List<RootLicenseWorkFlow>>(fileContent);
                foreach (var rootLicenseWorkFlow in rootLicenseWorkFlows)
                {
                    var licenseRule = await MapLicenseRuleAsync(rootLicenseWorkFlow);
                    rules.Add(licenseRule);
                }
            }
            else if(jsonDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                RootLicenseWorkFlow rootLicenseWorkFlow = JsonConvert.DeserializeObject<RootLicenseWorkFlow>(fileContent);
                var licenseRule = await MapLicenseRuleAsync(rootLicenseWorkFlow);
                rules.Add(licenseRule);
            }
            return rules;
        }

        public async Task<List<LicenseRule>> GetDeflatedLicenseRulesAsync()
        {
            //string licenseRuleFilesPath = Path.Combine(Environment.CurrentDirectory, Constants.licenseRulesPath);
            string licenseRuleFilesPath = Constants.licenseRulesPath;
            string[] files = Directory.GetFiles(licenseRuleFilesPath);
            Console.WriteLine(files);
            List<LicenseRule> deflatedLicenseRules = new List<LicenseRule>();
            foreach (string file in files)
            {
                List<LicenseRule> licenseRules = new List<LicenseRule>();
                licenseRules = await GetLicenseRulesInFileAsync(file);
                deflatedLicenseRules.AddRange(licenseRules);
            }
            return deflatedLicenseRules;
        }

        public async Task<LicenseRule> MapLicenseRuleAsync(RootLicenseWorkFlow rootLicenseWorkFlow)
        {
            var licenseRule = new LicenseRule();
            licenseRule.LicenseWorkFlow = rootLicenseWorkFlow.WorkflowName;
            licenseRule.LicenseWorkFlowContent = rootLicenseWorkFlow;
            return licenseRule;
        }
    }
}
