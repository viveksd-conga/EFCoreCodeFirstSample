using Amazon.S3.Model;
using Amazon.S3;
using EFCoreCodeFirstSample.AWS;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using EFCoreCodeFirstSample.Models;
using System.Collections.Generic;
using System;
using System.Text.Json;
using EFCoreCodeFirstSample.Models.Repository;
using System.Linq;

namespace EFCoreCodeFirstSample.Mapping.S3Model
{
    public class License_S3 : ILicense_S3
    {

        private readonly ILocalTenantOnboarding localTenantOnboarding;
        //private readonly IDataRepositoryLicense<License> dataRepositoryLicense;
        public License_S3(ILocalTenantOnboarding localTenantOnboarding) 
        {
            this.localTenantOnboarding = localTenantOnboarding;
        }
        public async Task<ListObjectsV2Response> GetFilesAsync()
        {
            var globalBucketName = Constants.globalBucketName;

            var amazonS3Client = localTenantOnboarding.SetClient();

            var request = new ListObjectsV2Request()
            {
                BucketName = globalBucketName,
                Prefix = Constants.customerLicenseStore
            };

            var response = await amazonS3Client.ListObjectsV2Async(request);
            return response;
        }
        
        public async Task<string> GetFileAsync(string key)
        {
            var globalBucketName = Constants.globalBucketName;
            var amazonS3Client = localTenantOnboarding.SetClient();
            var response = await amazonS3Client.GetObjectAsync(globalBucketName, key);
            using var reader = new StreamReader(response.ResponseStream);
            var fileContents = await reader.ReadToEndAsync();
            return fileContents;
        }

        public async Task<List<License>> DoWork(ProvisioningDetailWithOrgInfo provisioningDetailWithOrgInfo)
        {
            if(provisioningDetailWithOrgInfo == null)
            {
                throw new ArgumentNullException(nameof(provisioningDetailWithOrgInfo), "ProvisioningDeatils cannot be null");
            }
            var organizationFriendlyId = provisioningDetailWithOrgInfo.OrganizationFriendlyId;
            var accountInfo = provisioningDetailWithOrgInfo.AccountInfo;
            List<License> licenseList = new List<License>();
            if(provisioningDetailWithOrgInfo.Licenses.Any())
            {
                foreach (var license_item in provisioningDetailWithOrgInfo.Licenses)
                {
                    License license = new License();
                    license.Id = Guid.NewGuid();
                    license.LicenseName = license_item.Name;
                    license.LicenseType = license_item.Type;
                    license.Attributes = license_item.Attributes; //Can be null
                    license.InForce = license_item.InForce;
                    license.AccountId = accountInfo.ID; //Can be null
                    license.AccountName = accountInfo.Name; //Can be null
                    license.OrganizationFriendlyId = organizationFriendlyId;
                    license.LicenseExpiryDate = license_item.ExpiryDate;
                    license.LicenseStartDate= license_item.StartDate;
                    licenseList.Add(license);
                }
                return licenseList;
            }
            else
            { 
                return licenseList;
            }
        }

        public async Task<List<License>> GetLicensesAsync()
        {
            List<License> licenses = new List<License>();
            ListObjectsV2Response licenseFiles = await GetFilesAsync();
            foreach(var license in licenseFiles.S3Objects)
            {
                if(string.Compare(license.Key,Constants.customerLicenseStore) != 0)
                {
                    string licenseContent = await GetFileAsync(license.Key); //
                    ProvisioningDetailWithOrgInfo provisioningDetailWithOrgInfo = JsonConvert.DeserializeObject<ProvisioningDetailWithOrgInfo>(licenseContent);
                    List<License> deflatedLicenses = await DoWork(provisioningDetailWithOrgInfo);
                    licenses.AddRange(deflatedLicenses);
                }
            }
            return licenses;
        }
    }
}
