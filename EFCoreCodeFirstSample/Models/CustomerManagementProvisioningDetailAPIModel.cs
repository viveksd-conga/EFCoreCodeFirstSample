namespace EFCoreCodeFirstSample.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProvisioningDetailAPIModel
    {
        public List<LicenseAPIModel> Licenses { get; set; } = new List<LicenseAPIModel>();
        public Account AccountInfo { get; set; }
    }
}
