using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstSample.Models
{
    public class ProductWorkFlow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string WorkflowName { get; set; }
#nullable enable
        public string? WorkflowsToInject { get; set; }
        public int RuleExpressionType { get; set; }
        public List<Dictionary<string,string>>? GlobalParams { get; set; }
        public List<ProductRule>? Rules { get; set; }
    }
}
