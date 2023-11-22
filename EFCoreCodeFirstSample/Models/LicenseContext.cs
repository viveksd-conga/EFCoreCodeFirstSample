using EFCoreCodeFirstSample.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using EFCoreCodeFirstSample.Mapping.S3Model;
using System.Collections.Generic;

namespace EFCoreCodeFirstSample.Models
{
    public class LicenseContext : DbContext
    {
        private readonly ILicense_S3 license_S3;
        public LicenseContext(DbContextOptions<LicenseContext> options, ILicense_S3 license_S3) : base(options)
        {
            this.license_S3 = license_S3;
        }

        public List<License> getLicenses()
        {
            List<License> licenses =  license_S3.GetLicensesAsync().Result;
            if(licenses.Count == 0)
            {
                throw new Exception("Couldn't find any licenses");
            }    
            return licenses;
        }

        public DbSet<License> Licenses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var licenses = getLicenses();
            foreach(var license in licenses)
            {
                modelBuilder.Entity<License>().HasData(license);
            }
        }
    }
}
