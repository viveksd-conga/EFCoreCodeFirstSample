﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace EFCoreCodeFirstSample.Models
{
    public class LicenseRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LicenseWorkFlow { get; set; }
        [Column(TypeName = "jsonb")]
        public RootLicenseWorkFlow LicenseWorkFlowContent { get; set; }
    }
}

