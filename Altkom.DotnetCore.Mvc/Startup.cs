using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altkom.DotnetCore.FakeServices;
using Altkom.DotnetCore.FakeServices.Fakers;
using Altkom.DotnetCore.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Altkom.DotnetCore.Mvc
{
    public static class ServicesExtensions
    {
        public static void AddFakeCustomers(this IServiceCollection services)
        {
            services.AddScoped<ICustomersService, FakeCustomersService>();
            services.AddSingleton<CustomerFaker>();

            services.AddOptions();

            
        }
    }

    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false)
                .AddXmlFile("appsettings.xml", optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)

                
                ;

            Configuration = builder.Build();

        }
        

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFakeCustomers();

            var customerOptions = new CustomerOptions();
            Configuration.GetSection("CustomersModule").Bind(customerOptions);
            services.AddSingleton(customerOptions);

            services.Configure<CustomerOptions>(Configuration.GetSection("CustomersModule"));

           // services.Configure<CustomerOptions>(Configuration);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddAuthentication("BasicAuthorization")
            //    .AddScheme<>

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        //public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        //{


        //}

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            var qty = Configuration["CustomerQty"];

            var protocol = Configuration["Module1:protocol"];

            

            string connectionString = Configuration.GetConnectionString("MyConnectionString");

            var ports = Configuration["Module2:ports"];

            loggerFactory.AddLog4Net();

            if (env.EnvironmentName == "Testing")
            {

            }
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();


            app.UseAuthentication();

            app.UseMvc(routes =>
            {                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                    
                
            });

            app.UseMvc(routes =>
            {                
                routes.MapRoute(
                    name: "test",
                    template: "{controller=Products}/{action=Index}/{id?}");
            });

            app.Use(async (context, next) => await context.Response.WriteAsync("Hello "));
        }
    }
}
