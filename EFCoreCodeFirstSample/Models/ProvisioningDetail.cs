
namespace EFCoreCodeFirstSample.Models
{
    using Microsoft.AspNetCore.Http.HttpResults;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    public class ProvisioningDetail : BaseEntity
    {
        public List<LicenseModel> Licenses { get; set; } = new List<LicenseModel>();
        public Account AccountInfo { get; set; }
    }

    public class ProvisioningDetailWithOrgInfo : ProvisioningDetail
    {
        public string OrganizationFriendlyId { get; set; }
        public string TrackingId { get; set; }

        public ProvisioningDetailWithOrgInfo()
        {

        }

        public ProvisioningDetailWithOrgInfo(ProvisioningDetailAPIModel provisioningDetailAPIModel)
        {
            this.AccountInfo = provisioningDetailAPIModel.AccountInfo;
            this.Licenses = provisioningDetailAPIModel.Licenses?.Select(i => new LicenseModel(i))?.ToList();
        }

        public ProvisioningDetailWithOrgInfo(List<LicenseAPIModel> Licenses)
        {
            this.Licenses = Licenses?.Select(i => new LicenseModel(i))?.ToList();
        }
    }

    public class ProvisioningDetailHistory : ProvisioningDetailWithOrgInfo
    {
        public DateTime MovedTime { get; set; }

        // It's a new tracking id which is generated while update license api request, by whome the current license info moved to history
        public string MovedByTrackingId { get; set; }

        public ProvisioningDetailHistory()
        {

        }

        public ProvisioningDetailHistory(ProvisioningDetailWithOrgInfo provisioningDetailWithOrgInfo)
        {
            OrganizationFriendlyId = provisioningDetailWithOrgInfo.OrganizationFriendlyId;
            Licenses = provisioningDetailWithOrgInfo.Licenses;
            AccountInfo = provisioningDetailWithOrgInfo.AccountInfo;
            CreatedBy = provisioningDetailWithOrgInfo.CreatedBy;
            CreatedDate = provisioningDetailWithOrgInfo.CreatedDate;
            ModifiedBy = provisioningDetailWithOrgInfo.ModifiedBy;
            ModifiedDate = provisioningDetailWithOrgInfo.ModifiedDate;
            TrackingId = provisioningDetailWithOrgInfo.TrackingId;
        }
    }

    public class LicenseModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [DefaultValue(Constants.trail)]
        public string Type { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
        public bool InForce { get; set; }

        public LicenseModel () { }

        public LicenseModel(LicenseAPIModel licenseAPIModel)
        {
            this.Name = licenseAPIModel.Name;
            this.StartDate = licenseAPIModel.StartDate;
            this.ExpiryDate = licenseAPIModel.ExpiryDate;
            this.Type = licenseAPIModel.Type;
            this.Attributes = licenseAPIModel.Attributes;
        }
    }

    public class Account
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
}