using EFCoreCodeFirstSample.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using EFCoreCodeFirstSample.Mapping.S3Model;
using System.Collections.Generic;
using EFCoreCodeFirstSample.Mapping;
using System.IO;
using System.Linq;
using System.Text.Json;
using EFCoreCodeFirstSample.Models.ModelBuilderExtension;
using EFCoreCodeFirstSample.Models;

namespace EFCoreCodeFirstSample.Models
{
    public class LicenseContext : DbContext
    {
        public LicenseContext(DbContextOptions<LicenseContext> options) : base(options)
        {
        }

        public DbSet<License> Licenses { get; set; }
        public DbSet<LicenseRuleV2> LicenseRules { get; set; }
        public DbSet<ProductRule> ProductRules { get; set; }
    }
}
