using static Amazon.S3.Util.S3EventNotification;
using System.Collections.Generic;
using System;

namespace EFCoreCodeFirstSample.Models.Repository
{
    public interface IDataRepositoryLicenseRule<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(string licenseWorkFlow);
        void Add(LicenseRuleV2 entity);
        void AddMany(List<TEntity> entities);
        void Update(LicenseRuleV2 licenseRule, TEntity entity);
        void Delete(LicenseRuleV2 licenseRule);
    }
}
