using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstSample.Models
{
    public class License
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string OrganizationFriendlyId { get; set; }
        public string LicenseName { get; set; }
        public string LicenseType { get; set; }
#nullable enable
        public DateTime? LicenseStartDate { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public string? AccountName { get; set; }
        public string? AccountId { get; set; }
        public bool InForce { get; set; }

        [Column(TypeName = "jsonb")]
        public Dictionary<string, object>? Attributes { get; set; }
    }
}
