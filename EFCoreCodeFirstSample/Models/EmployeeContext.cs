using EFCoreCodeFirstSample.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using EFCoreCodeFirstSample.Mapping.S3Model;
using System.Collections.Generic;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerMetaData> CustomersMetaData { get; set; }

        //public DbSet<LicenseRule> LicenseRules { get; set; }

        public DbSet<LicenseRuleV2> LicenseRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Uncle",
                LastName = "Bob",
                Email = "uncle.bob@gmail.com",
                //DateOfBirth = new DateTime(1979, 04, 25),
                PhoneNumber = "999-888-7777"

            }, new Employee
            {
                EmployeeId = 2,
                FirstName = "Jan",
                LastName = "Kirsten",
                Email = "jan.kirsten@gmail.com",
                //DateOfBirth = new DateTime(1981, 07, 13),
                PhoneNumber = "111-222-3333"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 101,
                FirstName = "c1",
                LastName = "Bob",


            }, new Customer
            {
                CustomerId = 102,
                FirstName = "c12",
                LastName = "Bob",
            });
            modelBuilder.Entity<CustomerMetaData>().HasData(new CustomerMetaData
            {
                CustId = 103,
                OrganizationId = "xyz123",
                OrganizationFriendlyId = "123xyz",
            }, new CustomerMetaData
            {
                CustId = 104,
                OrganizationId = "xyz123321",
                OrganizationFriendlyId = "123321xyz",
            });
            
        }
    }
}
