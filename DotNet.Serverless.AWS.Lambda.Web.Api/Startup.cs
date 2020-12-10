using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.CompanyBogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.DepartmentBogus;
using DotNet.Serverless.AWS.Lambda.Web.Api.Bogus.EmployeeBogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NSwag;
using NSwag.Generation.Processors.Security;

namespace DotNet.Serverless.AWS.Lambda.Web.Api
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
            services.AddControllers();
            services.AddOpenApiDocument(config =>
            {
                config.Title = "Dotnet Api";
                config.Description = "A Dotnet Api to demonstrate the serverless";
            });
            services.AddSingleton<ICompanyBogus, CompanyBogus>();
            services.AddSingleton<IEmployeeBogus, EmployeeBogus>();
            services.AddSingleton<IDepartmentBogus, DepartmentBogus>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            
            app.UseOpenApi();
            
            app.UseSwaggerUi3(settings => { settings.Path = ""; });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}