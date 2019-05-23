using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Altkom.DotnetCore.Api
{

    public class MyMiddleware
    {
        private readonly RequestDelegate next;

        public MyMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            // TODO: logic
            context.Response.Headers.Add("MyMiddleware", "executed");

            await next(context);
        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyHandler(this IApplicationBuilder app, int options)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}