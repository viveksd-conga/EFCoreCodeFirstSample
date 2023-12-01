using EFCoreCodeFirstSample.Mapping;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Controllers
{
    [EnableQuery()]
    [Route("api/LicenseRule")]
    [ApiController]
    public class LicenseRuleV2Controller : ControllerBase
    {
        private readonly IDataRepositoryLicenseRule<LicenseRuleV2> licenseRuleRepository;
        private readonly LicenseContext licenseContext;
        public LicenseRuleV2Controller(IDataRepositoryLicenseRule<LicenseRuleV2> licenseRuleRepository, LicenseContext licenseContext)
        {
            this.licenseRuleRepository = licenseRuleRepository;
            this.licenseContext = licenseContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<LicenseRuleV2> licenseRules = licenseRuleRepository.GetAll();
            return Ok(licenseRules);
        }

        [HttpGet("{licenseWorkFlowName}", Name = "GetLicenseRule")]
        public IActionResult Get(string licenseWorkFlowName)
        {
            LicenseRuleV2 licenseRule = licenseRuleRepository.Get(licenseWorkFlowName);

            if (licenseRule == null)
            {
                return NotFound("The license rule record couldn't be found.");
            }
            return Ok(licenseRule);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<RootLicenseWorkFlow> licenseRules)
        {
            var licenseRuleMapping = new LicenseRuleMapping();
            if (licenseRules == null)
            {
                return BadRequest("licenseRules is null.");
            }
            List<LicenseRuleV2> mappedLicenseRules = new List<LicenseRuleV2>();
            foreach (var rootLicenseRule in licenseRules)
            {
                var licenseRule = await licenseRuleMapping.MapLicenseRuleAsync(rootLicenseRule);
                var mappedLicenseRule = new LicenseRuleV2
                {
                    LicenseWorkFlow = licenseRule.LicenseWorkFlow,
                    LicenseWorkFlowContent = licenseRule.LicenseWorkFlowContent,
                };
                mappedLicenseRules.Add(mappedLicenseRule);
                licenseRuleRepository.Add(mappedLicenseRule);
            }
            return (Ok(mappedLicenseRules));
        }

        [HttpPut("{workFlowName}")]
        public IActionResult Put(string workFlowName, [FromBody] LicenseRuleV2 licenseRule)
        {
            if (licenseRule == null)
            {
                return BadRequest("licenseRule is null.");
            }

            LicenseRuleV2 licenseRuleToUpdate = licenseRuleRepository.Get(workFlowName);
            if (licenseRuleToUpdate == null)
            {
                return NotFound("The LicenseRule record couldn't be found.");
            }

            licenseRuleRepository.Update(licenseRuleToUpdate, licenseRule);
            return NoContent();
        }

        [HttpDelete("{workFlowName}")]
        public IActionResult Delete(string workFlowName)
        {
            LicenseRuleV2 licenseRule = licenseRuleRepository.Get(workFlowName);
            if (licenseRule == null)
            {
                return NotFound("The license rule record couldn't be found.");
            }

            licenseRuleRepository.Delete(licenseRule);
            return NoContent();
        }
    }
}
