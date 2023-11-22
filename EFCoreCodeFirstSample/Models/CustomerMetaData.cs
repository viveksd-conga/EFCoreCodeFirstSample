using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace EFCoreCodeFirstSample.Models
{
    public class CustomerMetaData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustId { get; set; }
#nullable enable
        public string? OrganizationId { get; set; }
        public string? OrganizationFriendlyId { get; set; }
    }
}
