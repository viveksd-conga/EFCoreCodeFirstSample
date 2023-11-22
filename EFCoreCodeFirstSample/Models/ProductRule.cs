using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstSample.Models
{
    public class ProductRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string RuleName { get; set; }
#nullable enable
        public string? Properties { get; set; }
        public string? Operator { get; set; }
        public string? ErrorMessage { get; set; }
        public bool Enabled { get; set; }
        public int RuleExpressionType { get; set; }
        public string? WorkflowsToInject { get; set; }
        public List<string>? Rules { get; set; }
        public string? LocalParams { get; set; }
        public string? Expression { get; set; }
        public string? Action { get; set; }
        public bool SuccessEvent { get; set; }

    }
}
