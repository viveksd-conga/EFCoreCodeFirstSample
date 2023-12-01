using EFCoreCodeFirstSample.Mapping;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using System.Collections.Generic;
using System.Threading.Tasks;
using MSRulesEngine = global::RulesEngine;

namespace EFCoreCodeFirstSample.Controllers
{
    [EnableQuery()]
    [Route("api/ProductRule")]
    [ApiController]
    public class ProductRuleController : ControllerBase
    {
        private readonly IDataRepositoryProductRule<ProductRule> productRuleRepository;
        private readonly LicenseContext licenseContext;
        public ProductRuleController(IDataRepositoryProductRule<ProductRule> productRuleRepository, LicenseContext licenseContext)
        {
            this.productRuleRepository = productRuleRepository;
            this.licenseContext = licenseContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ProductRule> productRules = productRuleRepository.GetAll();
            return Ok(productRules);
        }

        [HttpGet("{productWorkFlowName}", Name = "GetProductRule")]
        public IActionResult Get(string productWorkFlowName)
        {
            ProductRule productRule = productRuleRepository.Get(productWorkFlowName);

            if (productRule == null)
            {
                return NotFound("The license rule record couldn't be found.");
            }
            return Ok(productRule);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] List<RootProductWorkFlow> productRules)
        //{
        //    var productRuleMapping = new ProductRuleMapping();
        //    if (productRules == null)
        //    {
        //        return BadRequest("productRules is null.");
        //    }
        //    List<ProductRule> mappedProductRules = new List<ProductRule>();
        //    foreach (var rootProductRule in productRules)
        //    {
        //        var productRule = await productRuleMapping.MapProductRuleAsync(rootProductRule);
        //        var mappedProductRule = new ProductRule
        //        {
        //            ProductWorkFlow = productRule.ProductWorkFlow,
        //            GlobalParams = productRule.GlobalParams,
        //            Rules = productRule.Rules,
        //        };
        //        mappedProductRules.Add(mappedProductRule);
        //        productRuleRepository.Add(mappedProductRule);
        //    }
        //    return (Ok(mappedProductRules));
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MSRulesEngine.Models.Workflow productRule)
        {
            var productRuleMapping = new ProductRuleMapping();
            if (productRule == null)
            {
                return BadRequest("productRule is null.");
            }
            var mappedProductRule = await productRuleMapping.MapProductRuleAsync(productRule);
            productRuleRepository.Add(mappedProductRule);
            return (Ok(mappedProductRule));
        }

        [HttpPut("{workFlowName}")]
        public IActionResult Put(string workFlowName, [FromBody] ProductRule productRule)
        {
            if (productRule == null)
            {
                return BadRequest("productRule is null.");
            }

            ProductRule productRuleToUpdate = productRuleRepository.Get(workFlowName);
            if (productRuleToUpdate == null)
            {
                return NotFound("The ProductRule record couldn't be found.");
            }

            productRuleRepository.Update(productRuleToUpdate, productRule);
            return NoContent();
        }

        [HttpDelete("{workFlowName}")]
        public IActionResult Delete(string workFlowName)
        {
            ProductRule productRule = productRuleRepository.Get(workFlowName);
            if (productRule == null)
            {
                return NotFound("The product rule record couldn't be found.");
            }

            productRuleRepository.Delete(productRule);
            return NoContent();
        }
    }
}
