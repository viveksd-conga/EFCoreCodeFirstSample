using System.Collections.Generic;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace EFCoreCodeFirstSample.Controllers
{
    [EnableQuery()]
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly EmployeeContext context;

        public CustomerController( EmployeeContext context)
        {
            this.context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            
            var employees = context.Customers.AsQueryable();
            return Ok(employees);
        }

        
    }
}