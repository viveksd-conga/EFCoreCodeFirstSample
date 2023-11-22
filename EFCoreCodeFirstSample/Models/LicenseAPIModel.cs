namespace EFCoreCodeFirstSample.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;

    public class LicenseAPIModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [DefaultValue(Constants.trail)]
        public string Type { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
    }
}