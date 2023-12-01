using EFCoreCodeFirstSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using MSRulesEngine = global::RulesEngine;

namespace EFCoreCodeFirstSample.Mapping
{
    public interface IProductRuleMapping
    {
        public Task<List<ProductRule>> GetProductRulesInFileAsync(string filePath);
        public Task<List<ProductRule>> GetDeflatedProductRulesAsync();
        public Task<ProductRule> MapProductRuleAsync(MSRulesEngine.Models.Workflow rootProductWorkFlow);
    }
}
