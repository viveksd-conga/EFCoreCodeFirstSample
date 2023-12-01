using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EFCoreCodeFirstSample.Models
{
    public class ProductRule
    {
        [Key]
        public string WorkflowName { get; set; }
        [Column(TypeName = "jsonb")]
        public IEnumerable<ScopedParam> GlobalParams { get; set; }
        [Column(TypeName = "jsonb")]
        public IEnumerable<Rule> Rules { get; set; }

    }
}
