using System.Collections.Generic;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EFCoreCodeFirstSample.Controllers
{
    [EnableQuery()]
    [Route("api/customerMetaData")]
    [ApiController]
    public class CustomerMetaDataController : ControllerBase
    {
        private readonly IDataRepositoryCustomerMetaData<CustomerMetaData> _dataRepository;
        private readonly EmployeeContext context;
        public CustomerMetaDataController(IDataRepositoryCustomerMetaData<CustomerMetaData> dataRepository, EmployeeContext context)
        {
            _dataRepository = dataRepository;
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var customerMetaData = context.Customers.AsQueryable();
            IEnumerable<CustomerMetaData> customerMetadata = _dataRepository.GetAll();
            return Ok(customerMetadata);
        }

        [HttpGet("{id}", Name = "GetCustomerMetaData")]
        public IActionResult Get(long id)
        {
            CustomerMetaData customerMetaData = _dataRepository.Get(id);

            if (customerMetaData == null)
            {
                return NotFound("The Customer record couldn't be found.");
            }

            return Ok(customerMetaData);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerMetaData customerMetaData)
        {
            if (customerMetaData == null)
            {
                return BadRequest("Employee is null.");
            }

            _dataRepository.Add(customerMetaData);
            return CreatedAtRoute(
                  "GetCustomerMetaData",
                  new { Id = customerMetaData.CustId },
                  customerMetaData);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            CustomerMetaData customerMetaData = _dataRepository.Get(id);
            if (customerMetaData == null)
            {
                return NotFound("The Customer record couldn't be found.");
            }

            _dataRepository.Delete(customerMetaData);
            return NoContent();
        }
    }
}
