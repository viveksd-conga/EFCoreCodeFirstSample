using EFCoreCodeFirstSample.AWS;
using EFCoreCodeFirstSample.Mapping;
using EFCoreCodeFirstSample.Mapping.S3Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace EFCoreCodeFirstSample.Models.ModelBuilderExtension
{
    public static class ModelBuilderExtension 
    { 
    
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var licenses = GetLicenses();
            foreach (var license in licenses)
            {
                //modelBuilder.Entity<License>().HasData(license);
            }
            var licenseRules = GetLicenseRules();
            foreach(var licenseRule in licenseRules)
            {
                //modelBuilder.Entity<LicenseRule>().HasData(licenseRule);
            }
            var productRules = GetProductRules();
            foreach(var productRule in productRules)
            {
                //modelBuilder.Entity<ProductRule>().HasData(productRule);
            }    
        }
        private static List<License> GetLicenses()
        {
            ILocalTenantOnboarding localTenantOnboarding = new LocalTenantOnboarding();
            License_S3 license_S3 = new License_S3(localTenantOnboarding);
            List<License> licenses = license_S3.GetLicensesAsync().Result;
            if (licenses.Count == 0)
            {
                throw new Exception("Couldn't find any licenses");
            }
            return licenses;
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
        public static List<ProductRule> GetProductRules()
        {
            IProductRuleMapping productRuleMapping = new ProductRuleMapping();
            List<ProductRule> productRules = productRuleMapping.GetDeflatedProductRulesAsync().Result;
            if(productRules.Count == 0)
            {
                throw new Exception("Couldn't find any Product Rules.");
            }
            return productRules;
        }
    }
}
