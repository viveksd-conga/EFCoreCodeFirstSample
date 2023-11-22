﻿// <auto-generated />
using System;
using EFCoreCodeFirstSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFCoreCodeFirstSample.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    partial class EmployeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EFCoreCodeFirstSample.Models.Customer", b =>
                {
                    b.Property<long>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CustomerId"));

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 101L,
                            FirstName = "c1",
                            LastName = "Bob"
                        },
                        new
                        {
                            CustomerId = 102L,
                            FirstName = "c12",
                            LastName = "Bob"
                        });
                });

            modelBuilder.Entity("EFCoreCodeFirstSample.Models.CustomerMetaData", b =>
                {
                    b.Property<long>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("CustId"));

                    b.Property<string>("OrganizationFriendlyId")
                        .HasColumnType("text");

                    b.Property<string>("OrganizationId")
                        .HasColumnType("text");

                    b.HasKey("CustId");

                    b.ToTable("CustomersMetaData");

                    b.HasData(
                        new
                        {
                            CustId = 103L,
                            OrganizationFriendlyId = "123xyz",
                            OrganizationId = "xyz123"
                        },
                        new
                        {
                            CustId = 104L,
                            OrganizationFriendlyId = "123321xyz",
                            OrganizationId = "xyz123321"
                        });
                });

            modelBuilder.Entity("EFCoreCodeFirstSample.Models.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("EmployeeId"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1L,
                            Email = "uncle.bob@gmail.com",
                            FirstName = "Uncle",
                            LastName = "Bob",
                            PhoneNumber = "999-888-7777"
                        },
                        new
                        {
                            EmployeeId = 2L,
                            Email = "jan.kirsten@gmail.com",
                            FirstName = "Jan",
                            LastName = "Kirsten",
                            PhoneNumber = "111-222-3333"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
