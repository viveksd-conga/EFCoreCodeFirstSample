using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirstSample.Models
{
    public class LicenseRuleV2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LicenseWorkFlow { get; set; }
        [Column(TypeName = "jsonb")]
        public RootLicenseWorkFlow LicenseWorkFlowContent { get; set; }
    }
}
