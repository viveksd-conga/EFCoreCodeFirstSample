using EFCoreCodeFirstSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Mapping
{
    public interface ILicenseRuleMapping
    {
        public Task<List<LicenseRule>> GetLicenseRulesInFileAsync(string filePath);
        public Task<List<LicenseRule>> GetDeflatedLicenseRulesAsync();
        public Task<LicenseRule> MapLicenseRuleAsync(RootLicenseWorkFlow rootLicenseWorkFlow);
    }
}
