using EFCoreCodeFirstSample.Models.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static Amazon.S3.Util.S3EventNotification;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class LicenseRulesManager : IDataRepositoryLicenseRule<LicenseRuleV2>
    {
        readonly LicenseContext licenseContext;
        public LicenseRulesManager(LicenseContext licenseContext)
        {
            this.licenseContext = licenseContext;
        }

        public void Add(LicenseRuleV2 entity)
        {
            licenseContext.LicenseRules.Add(entity);
            licenseContext.SaveChanges();
        }

        public void AddMany(List<LicenseRuleV2> entities)
        {
            licenseContext.LicenseRules.AddRange(entities);
            licenseContext.SaveChanges();
        }

        public void Delete(LicenseRuleV2 licenseRule)
        {
            licenseContext.LicenseRules.Remove(licenseRule);
            licenseContext.SaveChanges();
        }

        public LicenseRuleV2 Get(string licenseWorkFlow)
        {
            return licenseContext.LicenseRules.FirstOrDefault(e => e.LicenseWorkFlow == licenseWorkFlow);
        }

        public IEnumerable<LicenseRuleV2> GetAll()
        {
            return licenseContext.LicenseRules.AsQueryable();
        }

        public void Update(LicenseRuleV2 licenseRule, LicenseRuleV2 entity)
        {
            licenseRule.LicenseWorkFlow = entity.LicenseWorkFlow;
            licenseRule.LicenseWorkFlowContent = entity.LicenseWorkFlowContent;
            licenseContext.SaveChanges();
        }
    }
}
