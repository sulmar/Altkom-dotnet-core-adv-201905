using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Altkom.DotnetCore.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        private void HandleCustomers(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Hello Customers"));
        }

        
        private void HandleUsers(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Hello Users"));
        }

        private void HandleSensorsActive(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Hello sensors active"));
        }
        private void HandleSensorsNotActive(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Hello sensors not active"));
        }


        private void HandleFormat(IApplicationBuilder app)
        {
            app.Run(async context => await context.Response.WriteAsync("Hello format"));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("version", "1.1");

                await next.Invoke();
            });

            // app.UseMiddleware<MyMiddleware>();

            app.UseMyHandler(100);

            app.Map("/customers", HandleCustomers);
            app.Map("/users", HandleUsers);
            app.Map("/sensors", path =>
            {                                
                path.Map("/active", HandleSensorsActive);
                path.Map("/notactive", HandleSensorsNotActive);
                
               path.Run(async context => await context.Response.WriteAsync("Hello All Sensors"));
            });

            app.MapWhen(
                context => context.Request.Query.ContainsKey("format"), 
                HandleFormat);

            app.Run(async context => await context.Response.WriteAsync("Hello .NET Core"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
