using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreCodeFirstSample.Migrations;
using EFCoreCodeFirstSample.Models.Repository;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class LicenseManager : IDataRepositoryLicense<License>
    {
        readonly LicenseContext licenseContext;
        public LicenseManager(LicenseContext licenseContext)
        {
            this.licenseContext = licenseContext;
        }
        public void Add(License entity)
        {
            licenseContext.Licenses.Add(entity);
            licenseContext.SaveChanges();
        }
        public void AddMany(List<License> entity)
        {
            licenseContext.Licenses.AddRange(entity);
            licenseContext.SaveChanges();
        }

        public void Delete(License license)
        {
            licenseContext.Licenses.Remove(license);
            licenseContext.SaveChanges();
        }

        public License Get(Guid id)
        {
            return licenseContext.Licenses.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<License> GetAll()
        {
            return licenseContext.Licenses.AsQueryable();
        }

        public void Update(License license, License entity)
        {
            license.LicenseExpiryDate = entity.LicenseExpiryDate;
            license.OrganizationFriendlyId = entity.OrganizationFriendlyId;
            license.AccountId = entity.AccountId;
            license.AccountName = entity.AccountName;
            license.LicenseName = entity.LicenseName;
            license.LicenseType = entity.LicenseType;
            license.LicenseStartDate = entity.LicenseStartDate;
            license.InForce = entity.InForce;
            license.Attributes = entity.Attributes;
            licenseContext.SaveChanges();
        }
    }
}
