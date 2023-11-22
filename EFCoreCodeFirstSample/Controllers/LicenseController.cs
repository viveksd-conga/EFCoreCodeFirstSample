using System;
using System.Collections.Generic;
using System.Linq;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Newtonsoft.Json;

namespace EFCoreCodeFirstSample.Controllers
{
    [EnableQuery()]
    [Route("api/License")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly IDataRepositoryLicense<License> licenseRepository;
        private readonly LicenseContext licenseContext;

        public LicenseController(IDataRepositoryLicense<License> licenseRepos, LicenseContext licenseContext)
        {
            this.licenseRepository = licenseRepos;
            this.licenseContext = licenseContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var customerMetaData = context.Customers.AsQueryable();
            IEnumerable<License> licenses = licenseRepository.GetAll();
            return Ok(licenses);
        }

        [HttpGet("{id}", Name = "GetLicense")]
        public IActionResult Get(Guid id)
        {
            License license = licenseRepository.Get(id);

            if (license == null)
            {
                return NotFound("The license record couldn't be found.");
            }

            return Ok(license);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ProvisioningDetailWithOrgInfo license)
        {
            if (license == null)
            {
                return BadRequest("license is null.");
            }
            var accountInfo = license.AccountInfo;
            var organizationFriendlyId = license.OrganizationFriendlyId;
            var receivedLicense = license.Licenses;
            var mappedLicenses = new List<License>();
            foreach (var license_item in receivedLicense)
            {
                License mappedLicense = new License();
                mappedLicense.Id = Guid.NewGuid();
                mappedLicense.LicenseName = license_item.Name;
                mappedLicense.LicenseExpiryDate = license_item.ExpiryDate;
                mappedLicense.LicenseStartDate = license_item.StartDate;
                mappedLicense.LicenseType = license_item.Type;
                mappedLicense.Attributes = license_item.Attributes;
                mappedLicense.InForce = license_item.InForce;
                mappedLicense.AccountId = accountInfo.ID;
                mappedLicense.AccountName = accountInfo.Name;
                mappedLicense.OrganizationFriendlyId = organizationFriendlyId;
                mappedLicenses.Add(mappedLicense);
                licenseRepository.Add(mappedLicense);
            }
            return (Ok(mappedLicenses));
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] License license)
        {
            if (license == null)
            {
                return BadRequest("license is null.");
            }

            License licenseToUpdate = licenseRepository.Get(id);
            if (licenseToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            licenseRepository.Update(licenseToUpdate, license);
            return NoContent();
        }

        //[HttpPost]
        //public IActionResult PostBulk([FromBody] List<License> licenses)
        //{
        //    if(licenses.Count == 0 | licenses == null)
        //    {
        //        return BadRequest("No Licenses provided in the request body");
        //    }
        //    licenseRepository.AddMany(licenses);
        //    return CreatedAtRoute("GetLicense", licenses.Select(l => new { l.Id }).ToList(), licenses);
        //}

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            License license = licenseRepository.Get(id);
            if (license == null)
            {
                return NotFound("The license record couldn't be found.");
            }

            licenseRepository.Delete(license);
            return NoContent();
        }
    }
}
