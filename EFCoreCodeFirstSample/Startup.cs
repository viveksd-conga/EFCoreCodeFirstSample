using EFCoreCodeFirstSample.AWS;
using EFCoreCodeFirstSample.Mapping.S3Model;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.DataManager;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System;

namespace EFCoreCodeFirstSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmployeeContext>(opts => opts.UseNpgsql(Configuration["ConnectionString:EmployeeDB"]));
            services.AddDbContext<LicenseContext>(opts => opts.UseNpgsql(Configuration["ConnectionString:EmployeeDB"]));
            services.AddScoped<IDataRepositoryCustomerMetaData<CustomerMetaData>, CustomerMetaDataManager>();
            services.AddScoped<IDataRepositoryLicense<License>, LicenseManager>();
            services.AddScoped<IDataRepository<Employee>, EmployeeManager>();
            services.AddControllers().AddOData(options =>
                    options.Select().Filter().Count()
                    .OrderBy().Expand()
                    .AddRouteComponents("odata", GetModal()));
            services.AddScoped<ILocalTenantOnboarding, LocalTenantOnboarding>();
            services.AddScoped<ILicense_S3, License_S3>();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public static IEdmModel GetModal()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Employee>("Employee");
            builder.EntitySet<Customer>("Customer");
            builder.EntitySet<CustomerMetaData>("CustomerMetaData");
            builder.EntitySet<License>("License");

            return builder.GetEdmModel();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
