using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstSample.Models
{
    public class LicenseGlobalParam
    {
        public string Name { get; set; }
        public string Expression { get; set; }
    }

    public class LicenseRuleAPIModel
    {
        public string RuleName { get; set; }
#nullable enable
        public List<LicenseGlobalParam>? Properties { get; set; }
        public string? Operator { get; set; }
        public string? ErrorMessage { get; set; }
        public bool Enabled { get; set; }
        public int RuleExpressionType { get; set; }
        public List<LicenseRuleAPIModel>? WorkflowsToInject { get; set; }
        public List<LicenseRuleAPIModel>? Rules { get; set; }
        public List<LicenseGlobalParam>? LocalParams { get; set; }
        public string Expression { get; set; }
        public List<LicenseRuleAPIModel>? Actions { get; set; }
        public string? SuccessEvent { get; set; }
    }

    public class LicenseWorkflow
    {
        public string WorkflowName { get; set; }
#nullable enable
        public List<LicenseRuleAPIModel>? WorkflowsToInject { get; set; }
        public int RuleExpressionType { get; set; }
        public List<LicenseGlobalParam>? GlobalParams { get; set; }
        public List<LicenseRuleAPIModel>? Rules { get; set; }
    }
    public class RootLicenseWorkFlow : BaseEntity
    {
        public string WorkflowName { get; set; }
#nullable enable
        public List<LicenseRuleAPIModel>? WorkflowsToInject { get; set; }
        public int RuleExpressionType { get; set; }
        public List<LicenseGlobalParam>? GlobalParams { get; set; }

        public List<LicenseRuleAPIModel>? Rules { get; set; }
    }
}
