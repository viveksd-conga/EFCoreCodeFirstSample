using EFCoreCodeFirstSample.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class ProductRulesManager : IDataRepositoryProductRule<ProductRule>
    {
        readonly LicenseContext licenseContext;
        public ProductRulesManager(LicenseContext licenseContext)
        {
            this.licenseContext = licenseContext;
        }
        public void Add(ProductRule entity)
        {
            licenseContext.ProductRules.Add(entity);
            licenseContext.SaveChanges();
        }

        public void AddMany(List<ProductRule> entities)
        {
            licenseContext.ProductRules.AddRange(entities);
            licenseContext.SaveChanges();
        }

        public void Delete(ProductRule licenseRule)
        {
            licenseContext.ProductRules.Remove(licenseRule);
            licenseContext.SaveChanges();
        }

        public ProductRule Get(string WorkflowName)
        {
            return licenseContext.ProductRules.FirstOrDefault(e => e.WorkflowName == WorkflowName);
        }

        public IEnumerable<ProductRule> GetAll()
        {
            return licenseContext.ProductRules.AsQueryable();
        }

        public void Update(ProductRule productRule, ProductRule entity)
        {
            productRule.WorkflowName = entity.WorkflowName;
            productRule.GlobalParams = entity.GlobalParams;
            productRule.Rules = entity.Rules;
            licenseContext.SaveChanges();
        }
    }
}
